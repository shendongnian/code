    [DirectoryRdnPrefix("CN")]
    #region *UGLY CODE WARNING* Don't look in here....
    // When building the underlying DirectorySearcher filter the DirectoryObjectClass value is inserted in as: (objectClass={value})
    // The following injection will result in : (objectClass=user)(objectCategory=user)
    [DirectoryObjectClass("user)(objectCategory=user")]
    #endregion
    public class UserPrincipalExtended : UserPrincipal
    {
        public UserPrincipalExtended(PrincipalContext context) : base(context) { }
        public UserPrincipalExtended(PrincipalContext context, string samAccountName, string password, bool enabled)
            : base(context, samAccountName, password, enabled) { }
    }
