    foreach (var propertyInfo in modelType.GetProperties())
    {
        var openMethod = typeof(HtmlExtensions).GetMethod("GetPropertyEditor", BindingFlags.Static | BindingFlags.NonPublic);
        var genericMethod = openMethod.MakeGenericMethod(modelType, propertyInfo.PropertyType);
        var editorHtml = genericMethod.Invoke(null, new object[] { htmlHelper, propertyInfo });
        //add editorHtml to the form
    }
