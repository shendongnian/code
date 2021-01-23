	protected virtual AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor)
	{
		AuthorizationContext authorizationContext = new AuthorizationContext(controllerContext, actionDescriptor);
		foreach (IAuthorizationFilter current in filters)
		{
			current.OnAuthorization(authorizationContext);
			if (authorizationContext.Result != null)
			{
				break;
			}
		}
		return authorizationContext;
	}
