    public object BindModel(ControllerContext controllerContext, 
                              ModelBindingContext bindingContext)
            {
                var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (string.IsNullOrEmpty(valueResult.AttemptedValue))
                {
                    return 0m;
                }
                var modelState = new ModelState { Value = valueResult };
                object actualValue = null;
                try
                {
                    actualValue = Convert.ToDecimal(
                        valueResult.AttemptedValue.Replace(",", "."),
                        CultureInfo.InvariantCulture
                    );
                }
                catch (FormatException e)
                {
                    modelState.Errors.Add(e);
                }
    
                bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
                return actualValue;
            }
