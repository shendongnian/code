		private void ClearResponseCache(ActionExecutingContext filterContext)
		{
			if (filterContext == null)
				return;
			
			var urlHelper = new UrlHelper(filterContext.RequestContext);
			var resolvedAction = urlHelper.Action(
				filterContext.ActionDescriptor.ActionName, 
				filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
				new RouteValueDictionary(filterContext.ActionParameters));
			if (resolvedAction != null)
				filterContext.HttpContext.Response.RemoveOutputCacheItem(resolvedAction);
		}
