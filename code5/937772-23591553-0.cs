    After += ctx =>
    {
        if (ctx.Response.Headers.ContainsKey("Content-Type"))
        {
            ctx.Response.Headers["Content-Type"] += ";charset=ISO-8859-1";
        }
        else
        {
            ctx.Response.Headers.Add("Content-Type", ";charset=ISO-8859-1");
        }
    };
