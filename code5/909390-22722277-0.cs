       public class QueryStringToDictionary<TKey, TValue> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var modelBindingContext = new ModelBindingContext
            {
                
                ModelName = bindingContext.ModelName,
                ModelMetadata = new ModelMetadata(new EmptyModelMetadataProvider(), null, 
                    null, typeof(Dictionary<TKey, TValue>), bindingContext.ModelName),
                ValueProvider = new QueryStringValueProvider(controllerContext)
            };
            var temp = new DefaultModelBinder().BindModel(controllerContext, modelBindingContext);
            return temp;
        }
    }
        
