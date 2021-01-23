    public class CustomJsonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var data = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                JavaScriptSerializer js = new JavaScriptSerializer();
                var temp = js.Deserialize(data.AttemptedValue, bindingContext.ModelType);
                return temp;
            }
            catch
            {
                return null;
            }
        }
    }
