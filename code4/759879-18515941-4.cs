    public static MvcHtmlString MyTextBoxFor<TModel, TValue>(
        this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
    {
        var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        // in .NET 4.5 you can use the new GetCustomAttribute<T>() method to check
        // for a single instance of the attribute, so this could be slightly
        // simplified to:
        // var attr = metaData.ContainerType.GetProperty(metaData.PropertyName)
        //                    .GetCustomAttribute<ReadOnly>();
        // if (attr != null)
        bool isReadOnly = metaData.ContainerType.GetProperty(metaData.PropertyName)
                                  .GetCustomAttributes(typeof(ReadOnly), false)
                                  .Any();
        if (isReadOnly)
            return helper.TextBoxFor(expression, new { @readonly = "readonly" });
        else
            return helper.TextBoxFor(expression);
    }
