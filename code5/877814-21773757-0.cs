    var getPermissionsForRole = context.Roles.Where(roleid => roleid.RoleId == 1).Select(p => p.Permissions).ToList();
    var getAllPermissionGroup = context.PermissionGroups.ToList();
    
    List<PermissionGroup> jsonPg = new List<PermissionGroup>();
    
    foreach (var pg in getAllPermissionGroup)
    {
        PermissionGroup newPg = new PermissionGroup();
        newPg.PermissionGroupId = pg.PermissionGroupId;
        newPg.PermissionGroupName = pg.PermissionGroupName;
        newPg.Permissons = new List<Permission>();
    
        foreach (var pers in getPermissionsForRole[0])
        {
            if (pers.PermissionGroup.PermissionGroupId == pg.PermissionGroupId)
            {
                Permission newPe = new Permission();
                newPe.PermissionId = pers.PermissionId;
                newPe.PermissionName = pers.PermissionName;
    
                newPg.Permissons.Add(newPe);
            }
        }
    
        if (newPg.Permissons.Count > 0)
        {
            jsonPg.Add(newPg); 
        }
    }
    
    var json = JsonConvert.SerializeObject(jsonPg);
