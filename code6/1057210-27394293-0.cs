	try
	{
		System.IO.FileInfo fileInfo = new FileInfo(file.Name);
		string filename = GeneralMethods.MakeValidFileName(Path.GetFileNameWithoutExtension(file.Name));
		filename += fileInfo.Extension;
		byte[] obj = (byte[])file.OpenBinary();
		Response.Clear();
		Response.ClearContent();
		Response.ClearHeaders();
		Response.Cache.SetCacheability(System.Web.HttpCacheability.Server);
		var cd = new System.Net.Mime.ContentDisposition { FileName = file.Name, Inline=false};
		Response.AppendHeader("Content-Disposition", cd.ToString());
		Response.AppendHeader("Content-Length",obj.Length.ToString());
		Response.ContentType = MimeMapping.GetMimeMapping(filename);                
		if (Response.IsClientConnected)
			Response.BinaryWrite(obj);
		Response.Flush();
	   // Response.Close();
		HttpContext.Current.ApplicationInstance.CompleteRequest();
	}
	catch (Exception ex)
	{		
		Response.Redirect(Request.UrlReferrer.ToString());
	}
	finally
	{
	}
