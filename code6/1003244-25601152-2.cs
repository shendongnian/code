    public class IsoTimeSpanModelBinder: IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if(bindingContext.ModelType != typeof(TimeSpan))
            {
                return false;
            }
            var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if(val == null)
            {
                return false;
            }
            var key = val.RawValue as string;
            if(key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type for TimeSpan");
                return false;
            }
            try
            {
                bindingContext.Model = XmlConvert.ToTimeSpan(key);
                return true;
            }
            catch (Exception e)
            {
                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName, "Cannot convert value to TimeSpan: " + e.Message);
                return false;
            }
        }
    }
