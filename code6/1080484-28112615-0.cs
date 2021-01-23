        public class DecimalModelBinder : IModelBinder
        {
          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                actualValue = GeneralHelper.ToDecimal(valueResult.AttemptedValue);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
          }
        }
