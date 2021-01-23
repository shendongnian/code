    using(PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
        //? - to mark DateTime type as nullable
        DateTime? pwdLastSet = (DateTime?)user.LastPasswordSet;
        ...
    }
