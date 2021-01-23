    public static class StringExtensions
    {
        public static String RemoveAll(this string input, params Char[] charactersToRemove)
        {
            if(string.IsNullOrEmpty(input) || (charactersToRemove==null || charactersToRemove.Length==0))
                return input;
            var exclude = new HashSet<Char>(charactersToRemove); // removes duplicates and has constant lookup time
            var sb = new StringBuilder(input.Length);
            foreach (Char c in input)
            {
                if (!exclude.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
