    public static bool IsAdministrator()
    {
        var user = UmbracoContext.Current.Security.CurrentUser;
        return user != null && user.UserType.Alias == "admin";
    }
