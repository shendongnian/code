    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Globalization;
    using System.Threading;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                //US-en culture / default I'm developing on
                string currencyString = "$12.99"; //assuming got from: lstPrice.GetItemText(lstPrice.SelectedItem);
                CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
                double d = Convert.ToDouble(currencyString.Replace(ci.NumberFormat.CurrencySymbol, ""));
    
                //using custom culture
                currencyString = "12.99zł";
                ci = CultureInfo.GetCultureInfo("PL-pl");
                d = Convert.ToDouble(currencyString.Replace(ci.NumberFormat.CurrencySymbol, ""));
    
            }
        }
    }
