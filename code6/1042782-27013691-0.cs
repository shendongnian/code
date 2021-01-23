    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.AllKeys.Contains("path"))
        {
            string path = Server.UrlDecode(Request.QueryString["path"]);
            if (!(new FileInfo(path).Exists))
                return;
    
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    SetStream(fs);
                }
        }
    }
    private void SetStream(Stream stream)
    {
        byte[] bytes = new byte[(int)stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);
        Response.Buffer = true;
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=" + Server.UrlDecode(Request.QueryString["name"]));
        Response.BinaryWrite(bytes);
        Response.Flush();
    }
