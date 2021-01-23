    string fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    ModelState modelState;
    if (helper.ViewData.ModelState.TryGetValue(fullName, out modelState))
    {
        if (modelState.Errors.Count > 0)
        {
            builder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
        }
    }
