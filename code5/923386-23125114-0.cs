    using System;
    using www.webservicex.net;
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new CurrencyConvertorSoapClient("CurrencyConvertorSoap");
            var conv = client.ConversionRate(Currency.USD, Currency.EUR);
            Console.WriteLine("Conversion rate from USD to EUR is {0}", conv);
        }
    }
