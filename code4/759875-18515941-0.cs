    public static MvcHtmlString MyTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
    {
        var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        bool isReadOnly = metaData.ContainerType.GetProperty(metaData.PropertyName).GetCustomAttributes(typeof(ReadOnly), false).Any();
        if (isReadOnly)
            return helper.TextBoxFor(expression, new { @readonly = "readonly" });
        else
            return helper.TextBoxFor(expression);
    }
