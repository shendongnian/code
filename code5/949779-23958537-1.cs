    var newRule = new FileSystemAccessRule(
        new System.Security.Principal.NTAccount("Everyone"),
        FileSystemRights.FullControl,
        AccessControlType.Allow
    );
