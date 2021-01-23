     public static MvcHtmlString userButton(this HtmlHelper html, Manager user)
        {
            string buttonForManager = //...
            return new MvcHtmlString(buttonForManager);
        }
        public static MvcHtmlString userButton(this HtmlHelper html, Developer user)
        {
             string buttonForDeveloper = //...
            return new MvcHtmlString(buttonForDeveloper);
        }
