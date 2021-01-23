    var domainMembers = new List<Principal>();
    using (var context = new PrincipalContext( ContextType.Domain ))
    {
         GroupPrincipal grp = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, "Domain Users"); 
         foreach(var user in grp.GetMembers(false))
         {
              if(user)
              {
                  domainMembers.add(user);
              }
         }
    }
