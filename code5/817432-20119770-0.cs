	if (!String.IsNullOrEmpty(HttpContext.Current.Request.Headers["If-Modified-Since"]))
	{
		CultureInfo provider = CultureInfo.InvariantCulture;
		var lastMod = DateTime.ParseExact(HttpContext.Current.Request.Headers["If-Modified-Since"], "r", provider).ToLocalTime();
		if (lastMod < DateTime.UtcNow.ToLocalTime())
		{
			HttpContext.Current.Response.StatusCode = 304;
			HttpContext.Current.Response.StatusDescription = "Not Modified";
			return;
		}
	}
	Stream stream = null;
	const int bytesToRead = 100000;
	byte[] buffer = new Byte[bytesToRead];
	try
	{
		HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create(url);
		HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();
		if (fileReq.ContentLength > 0)
			fileResp.ContentLength = fileReq.ContentLength;
		stream = fileResp.GetResponseStream();
		var resp = HttpContext.Current.Response;
		resp.ContentType = fileResp.ContentType;
		resp.Cache.SetCacheability(HttpCacheability.Public);
		resp.Cache.SetExpires(DateTime.UtcNow.AddHours(maxAgeInHours));
		resp.Cache.SetLastModified(DateTime.UtcNow.AddMinutes(-1));
		MemoryStream ms = new MemoryStream();
		int length;
		do
		{
			if (resp.IsClientConnected)
			{
				length = stream.Read(buffer, 0, bytesToRead);
				resp.OutputStream.Write(buffer, 0, length);
				ms.Write(buffer, 0, length);
				resp.Flush();
				buffer = new Byte[bytesToRead];
			}
			else
			{
				length = -1;
			}
		} while (length > 0); //Repeat until no data is read
	}
	finally
	{
		if (stream != null)
		{
			//Close the input stream
			stream.Close();
			stream.Dispose();
		}
	}
}
