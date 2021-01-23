    public static TokenViewModel GetLastUserToken(this IIdentity identity)
    {
        var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
        return prinicpal.Claims.Where(c => c.Type == ClaimTypes.UserData).Select(c => c.Value).Select(i => new TokenViewModel{ TokenValue = i }).SingleOrDefault();
    }
