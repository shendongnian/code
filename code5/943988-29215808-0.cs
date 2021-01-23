    public class MoneyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the result
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            Money value;
            // if the result is null OR we cannot successfully parse the value as our custom type then let the default model binding process attempt it using whatever the default for Money is
            return valueProviderResult == null || !Money.TryParse(valueProviderResult.AttemptedValue, out value) ? base.BindModel(controllerContext, bindingContext) : value;
        }
    }
