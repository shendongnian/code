    public string GetUsername()
    {
        var principal = Thread.CurrentPrincipal;
        var identity = principal == null ? null : principal.Identity;
        return identity == null ? null : identity.Name;
    }
    public bool IsInRole(string role)
    {
        var principal = Thread.CurrentPrincipal;
        return principal == null ? false : principal.IsInRole(role);
    }
