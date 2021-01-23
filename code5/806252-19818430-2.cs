    private DataTable CreatePermissionDataTable(RoleInfoList roles)
    {
        DataTable permissions = new DataTable();
        permissions.Columns.Add("Permission Name", typeof(string));
        permissions.Columns["Permission Name"].ReadOnly = true;
        foreach (RoleInfo role in roles)
        {
            permissions.Columns.Add(role.Title, typeof(Boolean));
        }
        return permissions;
    }
