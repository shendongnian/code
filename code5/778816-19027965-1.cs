    public static void WriteResponse<T>(ref HttpContext ctx, object sender) 
        where T : class
    {
        var model = sender as T;
        var jsonObject = new JavaScriptSerializer().Serialize(model);
        ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
        ctx.Response.ContentType = "Content-type: application/json";
        ctx.Response.ContentEncoding = Encoding.UTF8;
        ctx.Response.Write(jsonObject);
    }
