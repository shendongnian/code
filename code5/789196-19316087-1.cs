    public static string StartupPath
    {
        get
        {
            if (Application.startupPath == null)
            {
                StringBuilder buffer =
                    new StringBuilder(260);
                UnsafeNativeMethods.GetModuleFileName(
                    NativeMethods.NullHandleRef, buffer, buffer.Capacity);
                Application.startupPath =
                    Path.GetDirectoryName(((object)buffer).ToString());
            }
            new FileIOPermission(
                FileIOPermissionAccess.PathDiscovery,
                Application.startupPath).Demand();
            return Application.startupPath;
        }
    }
