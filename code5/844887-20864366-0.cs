    public class AbstractModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.IsAbstract)
            {
                var typeName = bindingContext.ValueProvider.GetValue("$type");
                if (typeName == null)
                    throw new Exception("Cannot create abstract model");
                var type = Type.GetType(typeName);
                if (type == null)
                    throw new Exception("Cannot create abstract model");
                if (!type.IsSubclassOf(modelType))
                    throw new Exception("Incorrect model type specified");
                var model = Activator.CreateInstance(type);
                // this line is very important.
                // It updates the metadata (and type) of the model on the binding context,
                // which allows MVC to properly reflect over the properties
                // and assign their values. Without this,
                // it will keep the type as specified in the parameter list,
                // and only the properties of the base class will be populated
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
                return model;
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
