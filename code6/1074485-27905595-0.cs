    public class JobIdModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(JobId))
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                string id = value.AttemptedValue;
    
                return new JobId(id);
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
