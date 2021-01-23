    using System.DirectoryServices.AccountManagement;
...
    public static string GetFullName(string strLogin)
    {
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context, strLogin))
        {
            if (user == null) return string.Empty; // Do something else if user not found
            else return user.DisplayName;
        }
    }
