    //In Global.asax
    ModelBinders.Binders.Add(typeof(Property), new PropertyRegistrationModelBinder());
    ModelBinders.Binders.Add(typeof(Agent), new PropertyRegistrationModelBinder());
    //Updated ModelBinder look like this.
     public class PropertyRegistrationModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
        {
            if (propertyDescriptor.ComponentType == typeof(Property) || propertyDescriptor.ComponentType == typeof(Agent))
            {
                if(propertyDescriptor.Name == "Price" || propertyDescriptor.Name == "AnnualSales")
                {                    
                    var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue.Replace(",", string.Empty);
                    return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);
                }
            }            
            return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
        }
    } 
