    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType) {
        if ((typeof(QuestionAnswerInputModel) != bindingContext.ModelType)) {
            return null;
        }
        string prefix = bindingContext.ModelName;
        QuestionAnswerInputModel obj;
        if (bindingContext.ValueProvider.ContainsPrefix(prefix + "." + new FreeTextQuestionInputModel().GetPropertyName(m => m.FreeText))) {
            obj = new FreeTextQuestionInputModel();
        } else if (bindingContext.ValueProvider.ContainsPrefix(prefix + "." + new RatingQuestionInputModel().GetPropertyName(m => m.Rating))) {
            obj = new RatingQuestionInputModel();
        } else {
            return null;
        }
        bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, obj.GetType());
        bindingContext.ModelMetadata.Model = obj;
        return obj;
    }
