    public static GroupPrincipal GetGroupPrincipal(string FQDN, string AOuserName, string AOpassword, string groupName)
        {
            GroupPrincipal objGroupPrincipal = null;
            objGroupPrincipal = GroupPrincipal.FindByIdentity(GetPrincipalContext(FQDN, AOuserName, AOpassword), IdentityType.SamAccountName, groupName);
            return objGroupPrincipal;
        }
    public static PrincipalContext GetPrincipalContext(string FQDN, string AOuserName, string AOpassword)
        {
            PrincipalContext objPrincipalContext = null;
           objPrincipalContext = new PrincipalContext(ContextType.Domain, FQDN, AOuserName, AOpassword);
            return objPrincipalContext;
        }
