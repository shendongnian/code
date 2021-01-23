    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        switch (custom)
        {
            case "USER":
                return context.User.Identity.Name;
            default:
                return null;
        }
    }
