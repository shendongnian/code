    var lockedUsers = new List<UserPrincipal>();
    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         GroupPrincipal grp = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "Domain Users"); 
         foreach(var userPrincipal in grp.GetMembers(false))
         {
              var user = UserPrincipal.FindByIdentity(context, Identity.SamAccountName, userPrinciapl.UserPrincipalName);
              if(user)
              {
                  if (user.IsAccountLockedOut())
                  {
                       lockedUsers.Add(user);
                  }
              }
         }
    }
    //Deal with list here
