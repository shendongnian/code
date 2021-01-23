    StringBuilder sb = new StringBuilder();
    sb.Append("Hello!! ").Append(",");
    sb.Append("My").Append(",");
    sb.Append("name").Append(",");
    sb.Append("is").Append(",");
    sb.Append("Rajesh");
    sb.AppendLine();
    //use UTF8Encoding(true) if you want to use Byte Order Mark (BOM)
    UTF8Encoding utf8withNoBOM = new UTF8Encoding(false);
    byte[] bytearray;
    bytearray = utf8withNoBOM.GetBytes(sb.ToString());
    using (FileStream fileStream = new FileStream(System.Web.HttpContext.Current.Request.MapPath("~/" + "MyFileName.csv"), FileMode.Append, FileAccess.Write))
    {
	    StreamWriter sw = new StreamWriter(fileStream, utf8withNoBOM);
	
        //StreamWriter for writing bytestream array to file document
    	sw.BaseStream.Write(bytearray, 0, bytearray.Length);
	    sw.Flush();
    	sw.Close();
	
	    fileStream.Close();
    }
