	public ActionResult DownloadFile(string fname)
	{
		string filepath = HostingEnvironment.MapPath("~/App_Data/" + fname);
		if (!System.IO.File.Exists(filepath))
			return new RedirectResult("~/Some/Error/Page");
		return new FilePathResult(filepath, "text/plain");
	}
