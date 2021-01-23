    public static void WriteResponse<T>(HttpContext ctx, T sender)
    {
        var jsonObject = new JavaScriptSerializer().Serialize(sender);
        ctx.Response.AddHeader("Access-Control-Allow-Origin", "*");
        ctx.Response.ContentType = "Content-type: application/json";
        ctx.Response.ContentEncoding = Encoding.UTF8;
        ctx.Response.Write(jsonObject);
    }
    
    internal void GetShortInfo(HttpContext ctx, Shapefile shapefile)
    {
        var model = new Models.SfShortInfo
        {
            Count = shaefile.Count,
            Type = shapefile.Type.ToString()
        };
        
        ShapefileService.WriteResponse(ctx, model);
    }
