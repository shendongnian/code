    public class ModelBinder
    {
        public class DecimalModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext,
                                             ModelBindingContext bindingContext)
            {
                object result = null;
    
                // Don't do this here!
                // It might do bindingContext.ModelState.AddModelError
                // and there is no RemoveModelError!
                // 
                // result = base.BindModel(controllerContext, bindingContext);
    
                string modelName = bindingContext.ModelName;
                string attemptedValue =
                    bindingContext.ValueProvider.GetValue(modelName).AttemptedValue;
    
                // Depending on CultureInfo, the NumberDecimalSeparator can be "," or "."
                // Both "." and "," should be accepted, but aren't.
                string wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                string alternateSeperator = (wantedSeperator == "," ? "." : ",");
    
                if (attemptedValue.IndexOf(wantedSeperator) == -1
                    && attemptedValue.IndexOf(alternateSeperator) != -1)
                {
                    attemptedValue =
                        attemptedValue.Replace(alternateSeperator, wantedSeperator);
                }
    
                try
                {
                    if (bindingContext.ModelMetadata.IsNullableValueType
                        && string.IsNullOrWhiteSpace(attemptedValue))
                    {
                        return null;
                    }
    
                    result = decimal.Parse(attemptedValue, NumberStyles.Any);
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(modelName, e);
                }
    
                return result;
            }
        }
    }
