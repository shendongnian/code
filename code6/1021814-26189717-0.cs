       IList<Role> rolesToBeAdded = new List<Role>();
       IList<Role> rolesToBeDeleted = new List<Role>();
    
       foreach(Role role in existingRoles)
       {
           if(! selectedRoles.contains(role))
           rolesToBeDeleted.Add(role);
       }
    
       foreach(Role role in selectedRoles)
       {
           if(! existingRoles.contains(role))
           rolesToBeAdded.Add(role);
       }
