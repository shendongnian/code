    var list = con.PermissionGroups
        .Where(pg => pg.Permissons.Any(p => p.Roles.Any(r => r.RoleId == roleId)))
        .Select(pg => new
        {
            PermissionGroupId = pg.PermissionGroupId,
            PermissionGroupName = pg.PermissionGroupName,
            Permissions = pg.Permissons.Select(pe => new
            {
                PermissionId = pe.PermissionId,
                PermissionName = pe.PermissionName
            })
        });
