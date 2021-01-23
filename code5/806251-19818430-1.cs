    protected void rgPermissions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        // Data Access
        PermissionInfoList permissions = PermissionInfoList.GetPermissionInfoList();
        RoleInfoList roles = RoleInfoList.GetRoleList();
        // create datatable for permissions
        DataTable permissionTable = CreatePermissionDataTable(roles);
        foreach (PermissionInfo permission in permissions)
        {
            // Add permission name
            DataRow dataRow = permissionTable.NewRow();
            dataRow["Permission Name"] = permission.PermissionName;
            AddRow(permission, permissionTable, dataRow, roles);
        }
        rgPermissions.DataSource = permissionTable;
    }
