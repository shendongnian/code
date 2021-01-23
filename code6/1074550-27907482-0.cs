    class Program
    {
       static void Main(string[] args)
       {
          decimal cash = 3124.728m;
          Console.WriteLine("Result: {0}", cash.ToString("C",
             new MoneyFormatInfo("JPY", new System.Globalization.CultureInfo("fr-FR"))));
       }
    }
    
    class MoneyFormatInfo : IFormatProvider
    {
       System.Globalization.NumberFormatInfo numberFormat;
    
       public MoneyFormatInfo(string currencyCode, System.Globalization.CultureInfo culture)
       {
          numberFormat = culture.NumberFormat;
          numberFormat.CurrencySymbol = currencyCode;
       }
    
       public object GetFormat(Type formatType)
       {
          return numberFormat;
       }
    }
