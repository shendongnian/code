        private static MvcHtmlString ValidationMessageHelper(this HtmlHelper htmlHelper, ModelMetadata modelMetadata, string expression, string validationMessage, IDictionary<string, object> htmlAttributes)
        {
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            FormContext clientValidation = htmlHelper.ViewContext.GetFormContextForClientValidation();
            if (!htmlHelper.ViewData.ModelState.ContainsKey(fullHtmlFieldName) && clientValidation == null)
                return (MvcHtmlString)null;
            ModelState modelState = htmlHelper.ViewData.ModelState[fullHtmlFieldName];
            ModelErrorCollection modelErrorCollection = modelState == null ? (ModelErrorCollection)null : modelState.Errors;
            ModelError error = modelErrorCollection == null || modelErrorCollection.Count == 0 ? (ModelError)null : Enumerable.FirstOrDefault<ModelError>((IEnumerable<ModelError>)modelErrorCollection, (Func<ModelError, bool>)(m => !string.IsNullOrEmpty(m.ErrorMessage))) ?? modelErrorCollection[0];
            if (error == null && clientValidation == null)
                return (MvcHtmlString)null;
            TagBuilder tagBuilder = new TagBuilder("span");
            ...
            return TagBuilderExtensions.ToMvcHtmlString(tagBuilder, TagRenderMode.Normal);
        }
