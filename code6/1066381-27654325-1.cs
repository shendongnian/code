    public static class MyHelper
    {
        public static MvcHtmlString SafeHtml(this HtmlHelper html, string input)
        {
            string[] decodeItems = new string[] { "&#252;", "&#246;", "&#231;", "&#220;", "&#199;", "&#214;" };
            string str = System.Net.WebUtility.HtmlEncode(input);
            foreach (string s in decodeItems)
            {
                str = str.Replace(s, System.Net.WebUtility.HtmlDecode(s));
            }
            return new MvcHtmlString(str);
        }
    
        public static MvcHtmlString SafeHtmlV2(this HtmlHelper html, string input)
        {
            string str = System.Net.WebUtility.HtmlEncode(input).Replace("&#252;", "ü")
                   .Replace("&#246;", "ö")
                   .Replace("&#231;", System.Net.WebUtility.HtmlDecode("&#231;"))
                   .Replace("&#220;", System.Net.WebUtility.HtmlDecode("&#220;"))
                   .Replace("&#199;", System.Net.WebUtility.HtmlDecode("&#199;"))
                   .Replace("&#214;", System.Net.WebUtility.HtmlDecode("&#214;"));
            return new MvcHtmlString(str);
        }
    
    }
