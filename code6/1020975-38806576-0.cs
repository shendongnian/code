    FileInfo objFile = new FileInfo(filename);
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + filename));
    request.Credentials = new NetworkCredential(Ftp_Login_Name, Ftp_Login_Password);
    
    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
    Stream responseStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(responseStream);
    
    byte[] bytes = null;
    using (var memstream = new MemoryStream())
    {
    	reader.BaseStream.CopyTo(memstream);
    	bytes = memstream.ToArray();
    }
    
    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    Response.ContentType = "application/pdf";
    Response.AddHeader("Content-Disposition", "inline; filename=" + objFile.Name);
    Response.BinaryWrite(bytes);
    Response.End();
