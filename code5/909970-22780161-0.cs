    public void SubmitCustomForm()
    {
    	List<string> theErrors = new List<string>();
    
    	var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    	var dict = serializer.Deserialize<Dictionary<string, string>>(_Context.Request["formdata"]);
    
    	foreach (KeyValuePair<string, string> pair in dict)
    	{
    		theErrors.Add(pair.Key + " = " + pair.Value);
    	}
    
    	_Context.Response.Write(new
    	{
    		Valid = theErrors.Count == 0,
    		Errors = theErrors,
    		Message = "Form Submitted"
    	}.ToJson());			
    }
