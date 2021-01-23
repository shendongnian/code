    protected virtual bool OnPropertyValidating(
    	ControllerContext controllerContext,
    	ModelBindingContext bindingContext,
    	PropertyDescriptor propertyDescriptor,
    	Object value
    )
    {
        if(SomethingIsInvalid())
        {
             bindingContext.ModelState.AddModelError("Field", "Is Required");
        }
        base.OnPropertyValidating(controllerContext, bindingContext, propertyDescriptor)
    } 
