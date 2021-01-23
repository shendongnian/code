    //this code will create a new user on AD
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "SharePoint", "OU=Employees,DC=SharePoint,DC=Com"))
    {
        using (UserPrincipalExtension up = new UserPrincipalExtension(context))
        {
            //Set all others properties
            up.DialIn = true; //true = Allow access, false = Deny access, null = control access through policy
            up.Save();
         }
     }
    //this code will update a user
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, "SharePoint", "OU=Employees,DC=SharePoint,DC=Com"))
    {
        using (UserPrincipalExtension up = UserPrincipalExtension.FindByIdentity(context, SamAccountName))
        {
           //Set all others properties
           up.DialIn = true; //true = Allow access, false = Deny access, null = control access through policy
           up.Save();
        }
    }
