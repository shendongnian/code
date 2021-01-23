    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
        if(user != null)
        {
           // do something here....	    
        }
       
        // find the group in question
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
        // if found....
        if (group != null)
        {
           // iterate over members
           foreach (Principal p in group.GetMembers())
           {
               Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
               // do whatever you need to do to those members
           }
        }
    }
