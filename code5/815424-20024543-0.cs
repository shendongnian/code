    tms.SecurityRoles.Where(a => a.Name.ToLower() == "administrator")
                                         .Select(a=>a.SecurityRoleUsers.Where(a2 => a2.UserName.ToLower() == user.ToLower()));
    
    ***
    
    tms.SecurityRoles.Select(a=>a.SecurityRoleUsers.Where(a2 => a2.UserName.ToLower() == user.ToLower())).Where(a => a.Name.ToLower() == "administrator");
