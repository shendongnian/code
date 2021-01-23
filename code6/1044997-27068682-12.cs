    [OperationContract]
	[WebGet(ResponseFormat = WebMessageFormat.Json)]
	public async Task<string> TestLogin(int id, string callback)
	{
		if (HttpContext.Current.Session["user"] != null)
		{
			return new JavaScriptSerializer().Serialize(new word() { Name = "woot" });		  
		}
		else
			return new JavaScriptSerializer().Serialize(new word() { Name = "not logged" });
	}
