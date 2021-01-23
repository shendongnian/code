    public class MyModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelMetadata.AdditionalValues.ContainsKey(MyMarkerAttribute.MarkerKey))
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (value != null)
                {
                    // Here you could implement whatever custom binding logic you need
                    // for your property from the binding context
                    return value.ConvertTo(typeof(double));
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
