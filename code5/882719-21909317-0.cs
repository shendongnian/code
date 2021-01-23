    public class MyUrlsEnumModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            MyUrls temp;
            if (!Enum.TryParse(valueResult.AttemptedValue, out temp))
                return MyUrls.Url1;
            return temp;
        }
    }
