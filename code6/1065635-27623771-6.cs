    private bool CanRequestNotifications()
    {
    // In order to use the callback feature of the
    // SqlDependency, the application must have
    // the SqlClientPermission permission.
    try
    {
        SqlClientPermission perm =
            new SqlClientPermission(
            PermissionState.Unrestricted);
        perm.Demand();
        return true;
    }
    catch
    {
        return false;
    }
    }
