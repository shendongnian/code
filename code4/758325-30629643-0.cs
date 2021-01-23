        public static MvcHtmlString MyHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            var propertyName = expression.Body.ToString();
            propertyName = propertyName.Substring(propertyName.IndexOf(".") + 1);
            if (!string.IsNullOrEmpty(helper.ViewData.TemplateInfo.HtmlFieldPrefix))
                propertyName = string.Format("{0}.{1}", helper.ViewData.TemplateInfo.HtmlFieldPrefix, propertyName);
            TagBuilder span = new TagBuilder("span");
            span.Attributes.Add("name", propertyName);
            span.Attributes.Add("data-something", propertyName);
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                span.MergeAttributes(attributes);
            }
            return new MvcHtmlString(span.ToString());
        }
