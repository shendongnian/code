    public static MvcHtmlString DropDownListFor<TModel, TEnum>
       (this HtmlHelper<TModel> htmlHelper, 
        Expression<Func<TModel, TEnum>> expression, 
        string optionLabel = null, object htmlAttributes = null)
    {
        //This code is based on the blog - it's finding out if it nullable or not
        Type metaDataModelType = ModelMetadata
           .FromLambdaExpression(expression, htmlHelper.ViewData).ModelType;
        Type enumType = Nullable.GetUnderlyingType(metaDataModelType) ?? metaDataModelType;
    
        if (!enumType.IsEnum)
            throw new ArgumentException("TEnum must be an enumerated type");  
    
        IEnumerable<SelectListItem> items = Enum.GetValues(enumType).Cast<TEnum>()
           .Select(e => new SelectListItem
                   {
                      Text = e.GetDisplayName(),
                      Value = e.ToString(),
                      Selected = e.Equals(ModelMetadata
                         .FromLambdaExpression(expression, htmlHelper.ViewData).Model)
                   });
    
        return htmlHelper.DropDownListFor(
            expression,
            items,
            optionLabel,
            htmlAttributes
            );
    }
