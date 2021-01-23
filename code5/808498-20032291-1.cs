	public class QueryFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			object query = filterContext.ActionParameters["query"];
			Type queryType = query.GetType();
			Type modelType = queryType.GetInterfaces()[0].GetGenericArguments()[0];
			var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, modelType);
			// Here you should resolve your IQueryHandler<,> using IoC
			// 'Service Locator' pattern is used as quick-and-dirty solution to show that code works.
			var handler = ComponentLocator.GetComponent(handlerType) as IQueryHandler;
			var model = handler.Handle(query);
			filterContext.Controller.ViewData.Model = model;
		}
	}
