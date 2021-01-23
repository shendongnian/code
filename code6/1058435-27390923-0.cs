    public class CustomBinder : IModelBinder
    {
    	public object BindModel(ControllerContext controllerContext,
    							ModelBindingContext bindingContext)
    	{
    		HttpRequestBase request = controllerContext.HttpContext.Request;
    
    		string[] values = request.Form.GetValues("helloWorld");
    		if (values != null)
    		{
    			var notEmptyValues = values.Where(x => !string.IsNullOrEmpty(x));
    			if (notEmptyValues.Count() == 1)
    				return notEmptyValues.First();
    		}
    
    		return values;
    	}
    }
