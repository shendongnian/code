    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState {Value = valueResult};
            object actualValue = null;
            try
            {
                // Try to convert the actual number that was recieved.
                actualValue = Convert.ToDecimal(valueResult.AttemptedValue, CultureInfo.CurrentCulture);
            }
            catch
            {
                try
                {
                    // Replace any . with , and try to convert.
                    actualValue = Convert.ToDecimal(valueResult.AttemptedValue.Replace('.',','), CultureInfo.CurrentCulture);
                }
                catch
                {
                    try
                    {
                        // Replace any , with . and try to convert.
                        actualValue = Convert.ToDecimal(valueResult.AttemptedValue.Replace(',', '.'), CultureInfo.CurrentCulture);
                    }
                    catch (Exception ex)
                    {
                        modelState.Errors.Add(ex);                                               
                    }
                }
            }
            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
