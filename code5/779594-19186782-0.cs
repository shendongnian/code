            public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression, string customData)
            {
                return htmlHelper.CustomTextBoxFor(expression, customData, (IDictionary<string, object>)null);
            }
    
            public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
               Expression<Func<TModel, TProperty>> expression, string customData, object htmlAttributes)
            {
                IDictionary<string, object> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                attributes.Add("data-custom", customData);
                return htmlHelper.TextBoxFor(expression, new { data_custom = "customData" });
            }
