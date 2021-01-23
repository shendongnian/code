    public override Task Invoke(IOwinContext context)
    {
        var response = context.Response;
        response.ContentType = "application/javascript";
        response.StatusCode = 200;
        if (ClientCached(context.Request, scriptBuildDate))
        {
            response.StatusCode = 304;
            response.Headers["Content-Length"] = "0";
            response.Body.Close();
            response.Body = Stream.Null;
            return Task.FromResult<Object>(null);
        }
        response.Headers["Last-Modified"] = scriptBuildDate.ToUniversalTime().ToString("r");
        return response.WriteAsync(js);
    }
