    public static class StringExtensions
    {
        public static decimal ToTolerantDecimal(this string @this)
        {
           return string.IsNullOrEmpty(@this) ? 0.0m : decimal.Parse(@this);  
        }        
    }
