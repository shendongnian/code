    var list = con.PermissionGroups.Select(pg => new
    {
        PermissionGroupId = pg.PermissionGroupId,
        PermissionGroupName = pg.PermissionGroupName,
        Permissions = pg.Permissons.Select(pe => new
        {
            PermissionId = pe.PermissionId,
            PermissionName = pe.PermissionName
        }),
        Roles = pg.Permissions.SelectMany(pe => pe.Roles) 
    })
