     public static string TrimStart(this string value, string stringToTrim)
        {
            if (value.StartsWith(stringToTrim, StringComparison.CurrentCultureIgnoreCase))
            {
                return value.Substring(stringToTrim.Length);
            }
            return value;
        }
        public static string TrimEnd(this string value, string stringToTrim)
        {
            if (value.EndsWith(stringToTrim, StringComparison.CurrentCultureIgnoreCase))
            {                
                return value.Substring(0, value.Length - stringToTrim.Length);
            }
            return value;
        }
