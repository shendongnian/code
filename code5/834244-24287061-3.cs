    Type thisHandlerType = GetType();
    var methodToCall = thisPage.GetMethod(requestData["methodName"]);
    if (methodToCall != null)
    {
           var response = methodToCall.Invoke(this, new object[]{requestData});
           context.Response.Write(JsonHelper.SerializeJson(response));
    }
    
    public object Authorize(Dictionary<string, string> inputData)
	{
		User user = User.Get(inputData["name"]);
		if (user == null)
			return new { result = "false", responseText = "Frong user name or password!" };
		else
		        return new { result = true};
	}
