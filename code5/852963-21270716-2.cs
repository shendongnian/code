    context.Response.ContentType = "image/jpg";
    context.Response.Cache.SetMaxAge(TimeSpan.FromDays(1));
    context.Response.Cache.SetCacheability(HttpCacheability.Public);
    context.Response.Cache.SetSlidingExpiration(true);
    context.Response.TransmitFile(context.Server.MapPath("~/out.jpg"));
