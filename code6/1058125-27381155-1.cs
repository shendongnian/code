        public static IEnumerable<ModelError> ValidationErrors<TModel>(this HtmlHelper<TModel> htmlHelper, ModelMetadata modelMetadata)
        {
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);
            return ValidationErrors(htmlHelper, modelName);
        }
        public static IEnumerable<ModelError> ValidationErrors<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return ValidationErrors(htmlHelper, String.Empty);
        }
        private static IEnumerable<ModelError> ValidationErrors(this HtmlHelper htmlHelper, String modelName)
        {
            FormContext formContext = htmlHelper.ViewContext.FormContext;
            if (formContext == null)
                yield break;
            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName))
                yield break;
            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            if (modelState == null)
                yield break;
            ModelErrorCollection modelErrors = modelState.Errors;
            if (modelErrors == null)
                yield break;
            foreach(var err in modelErrors)
                yield return err;
        }
