    public class UTCDateTimeModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    
                // Check if the DateTime property being parsed is not null or "" (for JSONO
                if (value.AttemptedValue != null && value.AttemptedValue != "")
                {
                    // Parse the datetime
                    var dt = DateTime.ParseExact(value.AttemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);                
                    return dt;
                }
                else
                {
                    return null;
                }
            }
        }
