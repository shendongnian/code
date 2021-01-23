    public sealed class BindFromJsonAttribute : Attribute
    { }
    public class BindFromJsonModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.Attributes.OfType<Attribute>().Any(x => (x is BindFromJsonAttribute)))
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
                return JsonConvert.DeserializeObject(value, propertyDescriptor.PropertyType);
            }
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    }
