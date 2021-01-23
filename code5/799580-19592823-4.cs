    public static class Class1
    {
        public static int? ParseInt(string value)
        {
            // Match any digits at the beginning of the string with an optional
            // character for the sign value.
            var match = Regex.Match(value, @"^-?\d+");
            if(match.Success)
                return Convert.ToInt32(match.Value);
            else
                return null; // Because C# does not have NaN
        }
        public static bool TryParseInt(string value, out result)
        {
            var temp = ParseInt(value);
            if(temp == null)
            {
                result = 0;
                return false;
            }
            else
            {
                result = temp.Value;
                return true;
            }
        }
    }
