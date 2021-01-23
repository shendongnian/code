    namespace SomeNamespace
    {
        public static class RouteValueDictionaryExtensions
        {
            public static IHtmlString ToHtmlAttributes(this RouteValueDictionary dictionary)
            {
                var sb = new StringBuilder();
                foreach (var kvp in dictionary)
                {
                    sb.Append(string.Format("{0}=\"{1}\" ", kvp.Key, kvp.Value));
                }
                return new HtmlString(sb.ToString());
            }
        }
    }
