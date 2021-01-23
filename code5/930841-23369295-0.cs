    The ModelBinder code looks like this 
    
        public class CommaSeparatedLongArrayModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var values = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (values != null && !string.IsNullOrEmpty(values.AttemptedValue))
                {
                    // TODO: A minimum of error handling would be nice here
                    return values.AttemptedValue.Split(',').Select(x => long.Parse(x)).ToArray();
                }
                return base.BindModel(controllerContext, bindingContext);
            }
        }
