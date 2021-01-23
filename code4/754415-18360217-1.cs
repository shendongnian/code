    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "TEST");)
    {
        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "A_User_Name");
        foreach (var group in user.GetGroups())
        {
            Console.WriteLine(group.Name);
        }
    }
