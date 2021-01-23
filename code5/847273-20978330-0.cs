        public static MvcHtmlString DisplayEnum(this HtmlHelper helper, Enum e)
        {
            string result = string.Empty;
            var display = e.GetType()
                       .GetMember(e.ToString()).First()
                       .GetCustomAttributes(false)
                       .OfType<DisplayAttribute>()
                       .LastOrDefault();
            if (display != null)
            {
                result = display.GetName();
            }
            return helper.Label(result);
        }
