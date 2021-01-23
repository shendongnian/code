    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        byte[] img = GetImage(id);
        context.Response.ContentType = "image/jpeg"; // change accordingly
        context.Response.BinaryWrite(img);
        context.Response.Flush();
        context.Response.Close();   
    }
