    private void BindProperties(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
         IEnumerable<PropertyDescriptor> properties = GetFilteredModelProperties(controllerContext, bindingContext);
         foreach (PropertyDescriptor property in properties)
         {
              BindProperty(controllerContext, bindingContext, property);
         }
    }
