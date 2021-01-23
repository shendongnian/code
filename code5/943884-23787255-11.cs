    protected override void OnResultExecuting(ResultExecutingContext filterContext)
    {
    	//assuming this will be the type of all of your JSON data actions
    	var json = filterContext.Result as JsonResult;
    	if (json != null)
    	{
             //assuming you haven't overriden the default serializer here,
             //otherwise may be inconsistent with what the client sees
    	     LogMethod(new JavaScriptSerializer().Serialize(json.Data));
    	}
    }
