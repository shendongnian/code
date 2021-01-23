    public class StatementVMBinder : DefaultModelBinder
    {
        // this is the only method you need to override:
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType == typeof(StatementViewModel)) // so it will leave the other VM to the default implementation.
            {
                // this gets the value from the form collection, if it was in an input named "ViewModelName":
                var discriminator = bindingContext.ValueProvider.GetValue("ViewModelName");
                Type instantiationType;
                if (discriminator == "SomethingSomething")
                    instantiationType = typeof(ReliefVM);
                else // or do a switch case
                    instantiationType = typeof(RequestForSalaryVM);
                var obj = Activator.CreateInstance(instantiationType);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, instantiationType);
                bindingContext.ModelMetadata.Model = obj;
                return obj;
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
