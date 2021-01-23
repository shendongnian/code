    After += ctx =>
    {
        if (ctx.Response.Headers.ContainsKey("Content-Type"))
        {
            ctx.Response.Headers["Content-Type"] += ";charset=utf-8";
        }
        else
        {
            ctx.Response.Headers.Add("Content-Type", ";charset=utf-8");
        }
    };
