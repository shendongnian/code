    public void ProcessRequest(HttpContext context)
    {
        //Track your id
        //string id = context.Request.QueryString["id"];
        context.Response.Clear();
        context.Response.Buffer = true;
        context.Response.ContentType = "application/octet-stream";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + context.Request.QueryString["id"]);
        context.Response.WriteFile(context.Request.QueryString["id"]);
        context.Response.End();
    }
    public bool IsReusable
    {
        get { return false; }
    }
