	public class MyDecimalBinder :  DefaultModelBinder {
		protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor) {
			
			// use the propertyDescriptor to make your modifications, by calling SetProperty()
			...
			
			base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
		}
	}
