    public static class StringExtensions
    {
        public static string EnclosedTextSearch(this string theString, string left, string right)
        {
            Regex re = new Regex( left + @"(.+)" + right, RegexOptions.Compiled );                        
            string searchResult = "";
            if( String.IsNullOrEmpty(theString) == false )
            {
                Match match = re.Match( theString );
                if( match.Success )
                {
                    searchResult = match.Groups[1].ToString();                
                }
            }
            return searchResult;
        }
    }
