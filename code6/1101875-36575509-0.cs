    public class ValidModelsOnlyFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid)
			{
				base.OnActionExecuting(actionContext);
			}
			else
			{
				var exceptions = new List<Exception>();
				foreach (var state in actionContext.ModelState)
				{
					if (state.Value.Errors.Count != 0)
					{
						exceptions.AddRange(state.Value.Errors.Select(error => error.Exception));
					}
				}
				if (exceptions.Count > 0)
					throw new AggregateException(exceptions);
			}
		}
	}
