    public static MvcHtmlString RequiredIndicatorLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty)
    {
       return RequiredIndicatorLabelFor(html, modelProperty, null);
    }
    public static MvcHtmlString RequiredIndicatorLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> modelProperty, object htmlAttributes)
    {
        var htmlAttributesDict = new RouteValueDictionary(htmlAttributes);
        var metadata = ModelMetadata.FromLambdaExpression(modelProperty, html.ViewData);
        // To just add a class to the label tag
        // if (metadata.IsRequired)
        // {
        //     var cssClass = htmlAttributesDict["class"];
        //     htmlAttributesDict["class"] = (cssClass == null) ? "required" : cssClass + " required";
        // }
        // return html.LabelFor(modelProperty, metadata.GetDisplayName(), htmlAttributesDict);
        // To add text/HTML to content of label tag
        var builder = new TagBuilder("label");
        builder.MergeAttribute("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId());
        builder.MergeAttributes(htmlAttributesDict);
        builder.SetInnerText(metadata.GetDisplayName());
    
        if (metadata.IsRequired)
        {
            var spanBuilder = new TagBuilder("span");
            spanBuilder.AddCssClass("asterisk");
            spanBuilder.SetInnerText("*");
            builder.InnerHtml += " " + spanBuilder.ToString();
        }
        return new MvcHtmlString(builder.ToString());
    }
