    public static void WriteResponse<T>(HttpContext ctx, T model)
    {
        string jsonObject = new JavaScriptSerializer().Serialize(model);
        ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
        ctx.Response.ContentType = "Content-type: application/json";
        ctx.Response.ContentEncoding = Encoding.UTF8;
        ctx.Response.Write(jsonObject);
    }
    ShapefileService.WriteResponse<Models.SfShortInfo>(ctx, model);
