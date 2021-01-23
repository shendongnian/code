	private void WriteFile (Byte[] bytes, string fileName)
	{
		Response.Buffer = true;
		Response.Charset = "";
		Response.Cache.SetCacheability(HttpCacheability.NoCache);
		Response.ContentType = dt.Rows[0]["ContentType"].ToString();
		Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
		Response.BinaryWrite(bytes);
		Response.Flush();
		Response.End();
	}
