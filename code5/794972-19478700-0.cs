    public static class StringExtensions
    {
        public static bool Contains(this string value, string valueToCheck, 
                                    StringComparison comparisonType)
        {
            return value.IndexOf(valueToCheck, comparisonType) != -1;
        }
    }
