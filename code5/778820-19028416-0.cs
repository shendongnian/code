    public static void WriteResponse(HttpContext ctx, object model)
    {
        string jsonObject = new JavaScriptSerializer().Serialize(model);
        ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
        ctx.Response.ContentType = "Content-type: application/json";
        ctx.Response.ContentEncoding = Encoding.UTF8;
        ctx.Response.Write(jsonObject);
    }
