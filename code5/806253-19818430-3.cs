    private DataTable AddRow(PermissionInfo permission, DataTable permissions, DataRow dataRow, RoleInfoList roles)
    {
       
        // Add roles
        foreach (RoleInfo role in roles)
        {
            dataRow[role.Title] = permission.Roles.Any(r => r.RoleId == role.RoleId);
        }
        permissions.Rows.Add(dataRow);
        return permissions;
    }
