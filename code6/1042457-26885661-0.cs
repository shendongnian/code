    namespace your.namespace.Extensions
    {
        public static class NullableDecimalExtension
        {
            public static decimal? FormatWithNoRoundingDecimalPlaces(this decimal? initValue, int decimalPlaces)
            {
                if (decimalPlaces < 0)
                {
                    throw new ArgumentException("Invalid number. DecimalPlaces must be greater than Zero");
                }
                if (initValue.HasValue)
                    return (decimal?)(Math.Truncate(Math.Pow(10, decimalPlaces) * (double)initValue.Value) / Math.Pow(10, decimalPlaces));
                else
                   return null;
            }
        }
    }
