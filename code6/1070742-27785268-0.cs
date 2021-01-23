    private void sendFile(string path, string fileName)
    {
       
        FileStream fs = new FileStream(path, FileMode.Open);
        streamFileToUser(fs, fileName);
        fs.Close();
    }
        
    private void streamFileToUser(Stream str, string fileName)
        {
            byte[] buf = new byte[str.Length];  //declare arraysize
            str.Read(buf, 0, buf.Length);
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            HttpContext.Current.Response.AddHeader("Content-Length", str.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.OutputStream.Write(buf, 0, buf.Length);
            HttpContext.Current.Response.End();
        }
