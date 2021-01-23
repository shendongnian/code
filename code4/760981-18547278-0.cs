    [WebMethod]
    public byte[] GetPicture(string ImageURL)
    {
        if (ImageURL.StartsWith("http"))
                return new byte[0]; 
        string tmp = System.Web.Hosting.HostingEnvironment.MapPath("/" + ImageURL);
        string FileName = Microsoft.JScript.GlobalObject.unescape(tmp);
        if (System.IO.File.Exists(FileName))
        {
            FileStream fs = System.IO.File.OpenRead(FileName);
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, (int)fs.Length);
            fs.Close();
            return buf;
        }
        else
            return new byte[0];
    }
