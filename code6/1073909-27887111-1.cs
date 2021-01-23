    public class EncryptDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(int))
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (valueProviderResult != null)
                {
                    // Use your own logic here
                    bytes = ConvertUtilities.ToBytesFromHexa((string)valueProviderResult.RawValue);
                    return BitConverter.ToInt32(bytes, 0);
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
