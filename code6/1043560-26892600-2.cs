    public static class CurrencyExtensions
    {
        public static string ToUSCurrency(this decimal currency)
        {
            return currency.ToString("C", new CultureInfo("en-US")).Replace("US", "");
        }
    }
