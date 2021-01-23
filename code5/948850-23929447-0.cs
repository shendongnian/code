    public static class HtmlHelperExtensions
    {
        public static IHtmlString ToFriendlyUrl(this HtmlHelper helper, string urlToEncode)
        {
            var url = new StringBuilder();
    
            foreach (char ch in urlToEncode)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("and");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            url.Append('-');
                        }
                        break;
                }
            }
    
            return new MvcHtmlString(url.ToString());
        }
    }
