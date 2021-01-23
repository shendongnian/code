    public void ProcessRequest(HttpContext context)
    {
        string name = context.Request["Name"];
        string pass = context.Request["Pass"];
        context.Response.ContentType = "application/json";
        ...
    }
