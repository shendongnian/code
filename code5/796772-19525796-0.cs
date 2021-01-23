    var everyone = fsFile.GetAccessRules(true, true, 
                             typeof(System.Security.Principal.SecurityIdentifier))
        .Cast<System.Security.AccessControl.FileSystemAccessRule>()
        .SingleOrDefault(x => x.IdentityReference.Value == "S-1-1-0");
    var fullControlAllowed = everyone.AccessControlType == AccessControlType.Allow
                 && everyone.FileSystemRights.HasFlag(FileSystemRights.FullControl);
