    public class IntModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                actualValue = Convert.ToInt32(valueResult.AttemptedValue,
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                //Uncomment for default error
                //modelState.Errors.Add(e);
                actualValue = 0;
            }
    
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
