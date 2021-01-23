    public string GetRuleAsString(FileSystemAccessRule rule)
    {
        string userName = rule.IdentityReference.Value;
    
        //Example: Change    
        bool hasChangePermission = rule.FileSystemRights.HasFlag(FileSystemRights.ChangePermissions);
    
        //Example: Write
        bool hasWritePermission = rule.FileSystemRights.HasFlag(FileSystemRights.Write);
    
        return String.Format("{0}\n Change: {1}\n Write: {2}", userName, hasChangePermission, hasWritePermission);
    }
