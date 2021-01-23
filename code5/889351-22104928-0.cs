    HttpResponseMessage response = null;
    
    var eTag = Request.Headers.IfNoneMatch;
    
    if (eTag != null && eTag.Count > 0)
    {
        response = Request.CreateResponse(HttpStatusCode.NotModified);
    }
    else
    {
        string data = "asdfasdfs";
    
        string script = "(function(){DoSomething('" + data + "');})();";
    
        response = Request.CreateResponse(HttpStatusCode.OK);
    
        response.Content = new StringContent(script, Encoding.UTF8, "application/javascript");
        response.Content.Headers.LastModified = DateTime.Now;
        response.Headers.CacheControl = new CacheControlHeaderValue() { Public = true };
        response.Headers.ETag = new EntityTagHeaderValue("\"" + data + "\"");
    }
