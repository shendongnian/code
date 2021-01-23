	private FileContentResult getFileContentResult(string name, bool download = true)
	{
		if (!string.IsNullOrEmpty(name))
		{
			// don't forget to set the appropriate image MIME type 
			var result = new FileContentResult(System.IO.File.ReadAllBytes(name), "image/png");
			if (download)
			{
				result.FileDownloadName = Server.UrlEncode(name);
			}
			return result;
		}
		return null;
	}
