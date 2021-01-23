    public class StatementModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var statementTypeParameter = bindingContext.ValueProvider.GetValue("StatementType");
            if (statementTypeParameter == null)
                throw new InvalidOperationException("StatementType is not specified");
            StatementType statementType;
            if (!Enum.TryParse(statementTypeParameter.AttemptedValue, true, out statementType))
                throw new InvalidOperationException("Incorrect StatementType"); // not sure about the type of exception
            var model = SomeFactoryHelper.GetStatementByType(statementType); // returns an actual model by StatementType parameter
                                                                             // this could be a simple switch statement
            bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, model.GetType());
            bindingContext.ModelMetadata.Model = model;
            return model;
        }
    }
