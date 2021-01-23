    public static IHtmlString MyHelperFor<TModel, TValue>(
        this HtmlHelper<TModel> html, 
        Expression<Func<TModel, TValue>> expression
    )
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
        string name = metadata.DisplayName;
    
        return new HtmlString(string.Format("<th>{0}</th>", html.Encode(name)));
    }
