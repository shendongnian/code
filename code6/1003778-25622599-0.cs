    void Application_Error(object sender, EventArgs e)
	{
		var error = Server.GetLastError();
		var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;
		string path = Request.Path;
		if (code == 404)
		{
			if (new Regex(@"\/library\/", RegexOptions.IgnoreCase).IsMatch(path))
			{
				Server.ClearError();
				Response.Redirect(String.Format("~/Library/Error404"));
			}
		}
	}
