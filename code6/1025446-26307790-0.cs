    public override string GetVaryByCustomString(HttpContext context, string arg)
    {
        if(arg == "header" && context.Request.Headers["myheaders"]=="nocache")
        {
            return null;
        }
        return base.GetVaryByCustomString(context, arg);
    }
