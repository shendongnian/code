    protected void writeJsonData (string s) {
		HttpContext context=this.Context;
		HttpResponse response=context.Response;
		context.Response.ContentType = "text/json";
		byte[] b = response.ContentEncoding.GetBytes(s);
		response.AddHeader("Content-Length", b.Length.ToString());
		response.BinaryWrite(b);
		try
		{
			this.Context.Response.Flush();
			this.Context.Response.Close();
		}
		catch (Exception) { }
	}
