using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalCulatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double num = 0;
        private double num2 = 0;
        private string opera;
        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            Button n = (Button)sender;
            if (inp.Text == "Error")
                inp.Text = "";
            inp.Text += n.Content.ToString();
        }
        private void clear(object sender, RoutedEventArgs e)
        {
            inp.Text = "";
        }

        private void Dell(object sender, RoutedEventArgs e)
        {
            if(inp.Text.Length != 0)
                inp.Text = inp.Text.Substring(0, inp.Text.Length - 1);
        }

       

        private void Equal(object sender, RoutedEventArgs e)
        {
            string [] a = inp.Text.Split('+', '-','/','x','^');
            if(opera == "+")
                num = double.Parse(a[0]) + double.Parse(a[1]); 
            else if (opera == "-")
                num = double.Parse(a[0]) - double.Parse(a[1]);
            else if (opera == "x")
                num = double.Parse(a[0]) * double.Parse(a[1]);
            else if (opera == "/")
                num = double.Parse(a[0]) / double.Parse(a[1]);
            else
                num = Math.Pow(double.Parse(a[0]),double.Parse(a[1]));

            inp.Text = num.ToString();
        }

        private void Point(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(inp.Text) && !inp.Text.Contains("."))
                inp.Text += ".";

            if (inp.Text.Contains("+") || inp.Text.Contains("-") || inp.Text.Contains("x") || inp.Text.Contains("/") || inp.Text.Contains("^"))
            {
                string[] nums = inp.Text.Split('+', '-', '/', 'x', '^');
                if ( !nums[1].Contains("."))
                    inp.Text += ".";
            }
           


        }

        

        private void Sqrt(object sender, RoutedEventArgs e)
        {
            try
            {
                double res = Math.Sqrt(double.Parse(inp.Text));

                inp.Text = res.ToString();
            }
            catch
            {

                inp.Text = "Error";
            }
          
        }


        private void Operation(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            string? operation = btn.Content.ToString();
            if (!string.IsNullOrEmpty(inp.Text) && inp.Text != "Error")
            {
                if (operation == "sqr")
                {
                    if (!inp.Text.Contains("x") && !inp.Text.Contains("-") && !inp.Text.Contains("+") && !inp.Text.Contains("/") && !inp.Text.Contains("^"))
                    {
                        inp.Text += "^";
                        opera = "^";
                    }
                }

                else if (operation == "x")
                {
                    if (!inp.Text.Contains("^") && !inp.Text.Contains("-") && !inp.Text.Contains("+") && !inp.Text.Contains("/") && !inp.Text.Contains("x"))
                    {
                        inp.Text += "x";
                        opera = "x";
                    }
                }

                else if (operation == "/")
                {
                    if (!inp.Text.Contains("x") && !inp.Text.Contains("-") && !inp.Text.Contains("+") && !inp.Text.Contains("^") && !inp.Text.Contains("/"))
                    {
                        inp.Text += "/";
                        opera = "/";
                    }
                }
                else if (operation == "-")
                {
                    if (!inp.Text.Contains("x") && !inp.Text.Contains("^") && !inp.Text.Contains("+") && !inp.Text.Contains("/") && !inp.Text.Contains("-"))
                    {
                        inp.Text += "-";
                        opera = "-";
                    }
                }

                else
                {
                    if (!inp.Text.Contains("x") && !inp.Text.Contains("-") && !inp.Text.Contains("^") && !inp.Text.Contains("/") && !inp.Text.Contains("+"))
                    {
                        inp.Text += "+";
                        opera = "+";
                    }
                }


            }

        }
    }
}
