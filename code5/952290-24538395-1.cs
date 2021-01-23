        public static MvcHtmlString WriteHeader(this HtmlHelper html, string s, int? hLevel = 1, object htmlAttributes = null)
        {
            var hTag = new TagBuilder("h" + hLevel);
            hTag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            hTag.InnerHtml = s;
            return MvcHtmlString.Create(hTag.ToString());
        }
