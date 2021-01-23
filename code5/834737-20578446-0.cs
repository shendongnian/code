        public static MvcHtmlString DoTwice(this HtmlHelper htmlHelper, Func<MvcHtmlString, HelperResult> htmlContent)
        {
            var x = htmlContent(new MvcHtmlString("")).ToHtmlString() +
                    htmlContent(new MvcHtmlString("")).ToHtmlString();
            return new MvcHtmlString(x);
        }
