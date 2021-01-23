    public class ListModelBinder : System.Web.Mvc.DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model;
            var collectionBindingContext = new ModelBindingContext
            {
                ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, bindingContext.ModelType),
                ModelName = bindingContext.ModelName,
                ModelState = bindingContext.ModelState,
                PropertyFilter = bindingContext.PropertyFilter,
                ValueProvider = bindingContext.ValueProvider
            };
    
            return this.UpdateCollection(controllerContext, collectionBindingContext, model.GetType().GetGenericArguments()[0]);
        }
    
        private object UpdateCollection(ControllerContext controllerContext, ModelBindingContext bindingContext, Type elementType)
        {
            var collection = (IList)bindingContext.Model;
            var elementBinder = Binders.GetBinder(elementType);
            var modelList = new List<object>();
    
            for (var index = 0; index < collection.Count; index++)
            {
                var innerContext = new ModelBindingContext
                {
                    ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => collection[index], elementType),
                    ModelName = CreateSubIndexName(bindingContext.ModelName, index),
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider
                };
                    
                modelList.Add(elementBinder.BindModel(controllerContext, innerContext));
            }
    
            return modelList;
        }
    }
