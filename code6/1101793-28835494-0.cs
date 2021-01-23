    public class CharModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var dmb = new DefaultModelBinder();
            var result = dmb.BindModel(controllerContext, bindingContext);
            // ^^ result == null
            var rawValueAsChar = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ConvertTo(typeof(char));
            // ^^ rawValueAsChar == null
            var rawValueAsString = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
            if(!string.IsNullOrEmpty(rawValueAsString))
                return rawValueAsString.ToCharArray()[0];
            return null;
        }
    }
