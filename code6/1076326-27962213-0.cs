	var files = HttpContext.Current.Request.Files;
	var result = new List<HttpPostedFile>();
	for (int i = 0; i < files.AllKeys.Count; i++)
	{
		if (files.AllKeys[i] == "flTeklif")
		{
			result.Add(files.AllKeys[i];
		}
	}
