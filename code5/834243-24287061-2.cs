    public class AuthorizationHandler : IHttpHandler
    {
	public void ProcessRequest(HttpContext context)
	{
		var requestData = JsonHelper.DeserializeJson<Dictionary<string, string>>(context.Request.InputStream);
		context.Response.ContentType = "text/json";
		switch (requestData["methodName"])
		{
			case "Authorize":
				string password = requestData["password"];
				string userName = requestData["name"];
				context.Response.Write(JsonHelper.SerializeJson(Authorize(userName, password)));
				break;
		}
	}
	public bool IsReusable
	{
		get { return true; }
	}
	public object Authorize(string name, string password)
	{
		User user = User.Get(name);
		if (user == null)
			return new { result = "false", responseText = "Frong user name or password!" };
		else
		        return new { result = true};
	}
