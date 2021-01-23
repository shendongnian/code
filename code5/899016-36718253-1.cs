        public static MvcHtmlString DisplayName(this HtmlHelper html, object value)
        {
            var displayAttributes = (DisplayAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
            if (displayAttributes == null || displayAttributes.Length == 0)
            {
                return new MvcHtmlString(value.ToString());
            }
            return new MvcHtmlString(displayAttributes[0].Name);
        }
