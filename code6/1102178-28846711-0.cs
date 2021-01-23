    var samNames = new List<string>();
    using (var group = GroupPrincipal.FindByIndentity(principalContext, "GroupName"))
    {
         if (group != null)
         {
             var users = group.GetMembers(true);
             foreach (UserPrincipal user in users)
             {
                 samNames.add(user.SamAccountName);
             }
         }
    }
   
