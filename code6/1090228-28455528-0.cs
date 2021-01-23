    //Example: Change    
    bool hasChangePermission = rule.FileSystemRights.HasFlag(FileSystemRights.ChangePermissions);
    
    //Example: Write
    bool hasWritePermission = rule.FileSystemRights.HasFlag(FileSystemRights.Write);
