    if (System.IO.Directory.Exists(@"[SOME UNC PATH]"))
    {
        System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(@"[SOME UNC PATH]");
        var securityInfo = info.GetAccessControl();
        var rules = securityInfo.GetAccessRules(
                       true, 
                       true,
                       typeof(System.Security.Principal.SecurityIdentifier));
     
        foreach (var rule in rules)
        {
            var fileSystemRule = rule as System.Security.AccessControl.FileSystemAccessRule;
            if (ruleastype != null)
            {
                string user = fileSystemRule.IdentityReference.Translate(
                        typeof(System.Security.Principal.NTAccount)).Value;
                System.Diagnostics.Debug.Print("{0} User: {1} Permissions: {2}",
                    fileSystemRule.AccessControlType.ToString(),
                    user,
                    fileSystemRule.FileSystemRights.ToString());
            }
        }
    }
