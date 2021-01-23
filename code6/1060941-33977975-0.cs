    public static class StringExtension
    {
        public static bool ContainsValue(this string str, object value)
        {    
           return str.StartsWith(value.ToString()+",") ||  str.EndsWith(","+value) || str.Contains(","+value+",");
        }
    }
