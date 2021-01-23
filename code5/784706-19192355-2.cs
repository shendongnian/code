    ViewDataDictionary viewData = new ViewDataDictionary(html.ViewDataContainer.ViewData)
    {
        Model = metadata.Model,
        ModelMetadata = metadata,
        TemplateInfo = new TemplateInfo
        {
            FormattedModelValue = formattedModelValue,
            HtmlFieldPrefix = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName),
            VisitedObjects = new HashSet<object>(html.ViewContext.ViewData.TemplateInfo.VisitedObjects), // DDB #224750
        }
    };
