        private static readonly List<int> UnicodeCharCodesReplace = 
           new List<int>() { 160 }; // put integers here
        public static string UnicodeUnescape(this string input)
        {
            var chars = input.ToCharArray();
            var sb = new StringBuilder();
            foreach (var c in chars)
            {
                if (UnicodeCharCodesReplace.Contains(c))
                {
                    // Append &#code; instead of character
                    sb.Append("&#");
                    sb.Append(((int) c).ToString());
                    sb.Append(";");
                }
                else
                {
                    // Append character itself
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
