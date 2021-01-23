	public void ProcessRequest(HttpContext context)
	{
		HttpPostedFile file = context.Request.Files["file"];
		string virtualPath = "/Images/" + file.FileName;
		string path=HttpContext.Current.Server.MapPath("~") + virtualPath;
		file.SaveAs(path);
		context.Response.ContentType = "image/jpeg";
		context.Response.Write("<img src='"+virtualPath+"'/>");
	}
