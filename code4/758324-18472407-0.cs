    public static MvcHtmlString MyHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
    {
        var data = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        string propertyName = data.PropertyName;
        TagBuilder span = new TagBuilder("span");
        span.Attributes.Add("name", propertyName);
        span.Attributes.Add("data-something", "something");
        if (htmlAttributes != null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            span.MergeAttributes(attributes);
        }
        return new MvcHtmlString(span.ToString());
    }
