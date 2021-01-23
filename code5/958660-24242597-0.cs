    private static MvcHtmlString GetPropertyEditor<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, PropertyInfo propertyInfo)
    {
        //Get property lambda expression like "m => m.Property"
        var modelType = typeof(TModel);
        var parameter = Expression.Parameter(modelType, "m");
        var property = Expression.Property(parameter, propertyInfo.Name);
        var propertyExpression = Expression.Lambda<Func<TModel, TProperty>>(property, parameter);
        //Get html string with label, editor and validation message
        var editorContainer = new TagBuilder("div");
        editorContainer.AddCssClass("editor-container");
        editorContainer.InnerHtml += htmlHelper.LabelFor(propertyExpression);
        editorContainer.InnerHtml += htmlHelper.EditorFor(propertyExpression);
        editorContainer.InnerHtml += htmlHelper.ValidationMessageFor(propertyExpression);
        return new MvcHtmlString(editorContainer.ToString());
    }
