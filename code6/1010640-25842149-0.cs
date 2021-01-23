    public override string GetVaryByCustomString(HttpContext context, string arg)
    {
        if (arg == "language")
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }
        return string.Empty;
    }
