    public static class StringExtensions
    {
        public static string StripHTML(this string htmlString)
        {
            if (string.IsNullOrEmpty(htmlString)) return htmlString;
    
            string pattern = @"<(.|\n)*?>";
    
            string s = Regex.Replace(htmlString, pattern, string.Empty);
    
            return s;
        }
    }
