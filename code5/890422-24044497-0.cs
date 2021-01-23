	private class ActionSelector 
		: AsyncControllerActionInvoker
	{
		// Needed because FindAction is protected, and we are changing it to be public
		public new ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
		{
			return base.FindAction(controllerContext, controllerDescriptor, actionName);
		}
	}
