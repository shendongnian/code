    public class PropertyModelBinder : DefaultModelBinder
    {     
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if(propertyDescriptor.ComponentType == typeof(PropertyModel))
            {
                if (propertyDescriptor.Name == "Price")
                {
                    var obj=   bindingContext.ValueProvider.GetValue("Price");
                    return Convert.ToInt32(obj.AttemptedValue.ToString().Replace(",", ""));
                }
            }
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }       
    }
