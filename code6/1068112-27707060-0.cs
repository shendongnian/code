    namespace YourNamespace
    {
        public static class CustomHelpers
        {
            public static MvcHtmlString TextboxWithProperty(this HtmlHelper html, string property)
            {
                StringBuilder result = new StringBuilder();
                result.AppendFormat("<input {0} />", property);
                return MvcHtmlString.Create(result.ToString());
            }
        }
    }
