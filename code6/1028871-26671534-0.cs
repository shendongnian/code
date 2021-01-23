    public static string GetAdUserProperty(string sUser, string sProperty)
    {
        var domain = new PrincipalContext(ContextType.Domain);
        var user = UserPrincipal.FindByIdentity(domain, sUser);
        var property = GetPropValue(user, sProperty);
        return (string) (user != null ? property : null);
    }
    public static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
