    public static MvcHtmlString RenderForm<TModel>(this HtmlHelper<TModel> htmlHelper)
    {
        var modelType = typeof(TModel);
        var form = new TagBuilder("form");
        foreach (var propertyInfo in modelType.GetProperties())
        {
            //call generic GetPropertyEditor<TModel, TProperty> with the type of this property
            var openMethod = typeof(HtmlExtensions).GetMethod("GetPropertyEditor", BindingFlags.Static | BindingFlags.NonPublic);
            var genericMethod = openMethod.MakeGenericMethod(modelType, propertyInfo.PropertyType);
            var editorHtml = genericMethod.Invoke(null, new object[] { htmlHelper, propertyInfo });
            //add the html to the form
            form.InnerHtml += editorHtml;
        }
        return new MvcHtmlString(form.ToString());
    }
