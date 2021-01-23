    private static void DownloadFile(string path)
	{
		FileInfo file = new FileInfo(path);
		byte[] fileConent = File.ReadAllBytes(path);
		HttpContext.Current.Response.Clear();
		HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", file.Name));
		HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
		HttpContext.Current.Response.ContentType = "application/octet-stream";
		HttpContext.Current.Response.BinaryWrite(fileConent);
		file.Delete();
		HttpContext.Current.Response.End();
	}
