    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            NumberFormatInfo nfi = new NumberFormatInfo()
            {
                CurrencySymbol = "$$s. ",
                CurrencyGroupSeparator = ".",
                CurrencyDecimalSeparator = ",",
                NegativeSign = "-",
                CurrencyNegativePattern = 2
            };
            
            double d = double.Parse("$$s. 1.123,00",
                NumberStyles.Number | NumberStyles.AllowCurrencySymbol,
                nfi);
            Console.WriteLine(d);
        }
    }
