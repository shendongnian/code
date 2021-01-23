    System.IO.FileInfo file = new System.IO.FileInfo(context.Server.MapPath("~/out.png"));
    string eTag = file.Name.GetHashCode().ToString() + file.LastWriteTimeUtc.Ticks.GetHashCode().ToString();
    var browserETag = context.Request.Headers["If-None-Match"];
    
    context.Response.ClearHeaders();
    if(browserETag == eTag)
    {
        context.Response.Status = "304 Not Modified";
        context.Response.End();
        return;
    }
    context.Response.ContentType = "image/jpg";
    context.Response.Cache.SetMaxAge(TimeSpan.FromDays(1));
    context.Response.Cache.SetCacheability(HttpCacheability.Public);
    context.Response.Cache.SetSlidingExpiration(true);
    context.Response.Cache.SetETag(eTag);
    context.Response.TransmitFile(file.FullName);
