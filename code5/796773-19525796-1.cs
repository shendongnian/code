    var everyone = fsFile.GetAccessRules(true, true, typeof(SecurityIdentifier))
        .Cast<FileSystemAccessRule>()
        .SingleOrDefault(x => x.IdentityReference.Value == "S-1-1-0");
    bool fullControlAllowed = everyone != null
                 && everyone.AccessControlType == AccessControlType.Allow
                 && everyone.FileSystemRights.HasFlag(FileSystemRights.FullControl);
