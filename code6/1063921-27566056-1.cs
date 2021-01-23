    public class RequireValidModel : ActionFilterAttribute
    {
    	/// <summary>
    	/// Called by the ASP.NET MVC framework before the action method executes.
    	/// </summary>
    	/// <param name="filterContext">The filter context.</param>
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		ModelStateDictionary state = filterContext.Controller.ViewData.ModelState;
    
    		if (!state.IsValid)
    		{
    			var perPropertyMessages = state.Where(kvp => kvp.Value.Errors.Count > 0)
    										   .Select(kvp =>
    											   new
    											   {
    												   Property = kvp.Key,
    												   Value = kvp.Value.Value != null ? kvp.Value.Value.AttemptedValue: null,
    												   ErrorMessages = kvp.Value.Errors.Select(err => err.Exception != null ? err.Exception.Message : err.ErrorMessage)
    											   })
    										   .Select(propertyErrors =>
    											   new
    											   {
    												   propertyErrors.Property,
    												   propertyErrors.Value,
    												   ErrorMessages = string.Join("\n", propertyErrors.ErrorMessages)
    											   })
    										   .Select(
    											   propertyErrors =>
    												   string.Format("(property: {0}, attempted value: {1}, errors: {2}\n)", propertyErrors.Property,
    													   propertyErrors.Value, propertyErrors.ErrorMessages));
    
    			var finalMessage = string.Format("Invalid model state:\n{0}", string.Join(",\n", perPropertyMessages));
    
    			throw new InvalidOperationException(finalMessage);
    		}
    	}
    }
