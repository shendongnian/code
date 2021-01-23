    public void ProcessRequest(HttpContext context)
    {
        //context.Response.Redirect("http://api.soundcloud.com/tracks/148976759/stream?client_id=201b55a1a16e7c0a122d112590b32e4a");
        // you can use above or else below
        byte[] content = null;
        string fileName = context.Server.MapPath(@"\mp3\") + context.Request["file_name"];
    
        if (File.Exists(fileName))
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                content = new byte[System.Convert.ToInt32(stream.Length)];
                stream.Read(content, 0, System.Convert.ToInt32(stream.Length));
                context.Response.ContentType = "audio/mp3";
                context.Response.OutputStream.Write(content, 0, content.Length);
            }
        }
    }
<audio src="Handler1.ashx" controls></audio>
