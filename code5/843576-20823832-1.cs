    using System.DirectoryServices.AccountManagement;
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
         UserPrincipal currentUser = UserPrincipal.Current;
         string userLdapPath = currentUser.DistinguishedName;
    }
