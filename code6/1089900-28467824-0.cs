     public class EmptyStringModelBinder : System.Web.Mvc.IModelBinder
        {
            public object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
            {
                string key = bindingContext.ModelName;
                ValueProviderResult val = bindingContext.ValueProvider.GetValue(key);
                if (val != null)
                {
                    var s = val.AttemptedValue as string;
                    if (s != null && (s.IsEmpty() || s.Trim().IsEmpty()))
                    {
                        return null;
                    }
    
                    return val.AttemptedValue;
                }
    
                return null;
            }
        }
