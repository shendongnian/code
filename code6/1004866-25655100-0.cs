    var lockedUsers = new List<UserPrincipal>();
    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         using (var user = UserPrincipal.FindByIdentity( context,
                                                         IdentityType.SamAccountName,
                                                         name ))
         {
              if (user.IsAccountLockedOut())
              {
                  lockedUsers.Add(user);
              }
         }
    }
    //Deal with list here
