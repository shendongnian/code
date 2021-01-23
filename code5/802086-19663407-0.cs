    public override Task Invoke(IOwinContext context)
    {
        var response = context.Response;
        response.ContentType = "application/javascript";
    
        if (ClientCached(context.Request, scriptBuildDate))
        {
            response.StatusCode = 304;
            
            //Close the existing body just in case
            response.Body.Close();
            response.Body = Stream.Null;
        }
        else
        {
            response.StatusCode = 200;
            response.Headers["Last-Modified"] = scriptBuildDate.ToUniversalTime().ToString("r");
    
            return context.Response.WriteAsync(js);
        }
    }
