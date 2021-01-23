    public static class StringExtension
    {
        public static bool HasCurrencySymbol(this string input)
        {
            return input.Any(s => char.GetUnicodeCategory(s) == System.Globalization.UnicodeCategory.CurrencySymbol);
        }
    }
