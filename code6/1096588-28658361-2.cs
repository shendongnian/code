        public class FormOnlyModelBinder: DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {            
                ModelBindingContext newBindingContext = new ModelBindingContext()
                {
                    ModelMetadata = bindingContext.ModelMetadata,
                    ModelName = bindingContext.ModelName,
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    FallbackToEmptyPrefix = bindingContext.FallbackToEmptyPrefix,
                    ValueProvider = new FormValueProvider(controllerContext),                
                };
                return base.BindModel(controllerContext, newBindingContext);
            }
        }
