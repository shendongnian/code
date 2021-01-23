    public class DoubleModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (string.IsNullOrEmpty(valueResult.AttemptedValue))
            {
                return double.NaN;
            }
            return valueResult;
        }
    }
     protected void Application_Start()
     {
         ModelBinders.Binders.Add(typeof(double), new DoubleModelBinder());
     }
