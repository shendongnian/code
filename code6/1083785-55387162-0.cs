    string currentUserID = HttpContext.Current.User.Identity.Name;
    using (PrincipalContext adContext = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal currentUser = UserPrincipal.FindByIdentity(adContext, currentUserID);
        return string.Format("{0} {1}", currentUser.GivenName, currentUser.Surname);
    }
