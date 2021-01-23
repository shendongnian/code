    public static void SetFilePermissions(string path)
    {
        SetFileFolderPermissions
        (
            new FileInfo(path), 
            new FileSystemAccessRule
            (
                "TestAccount", 
                FileSystemRights.FullControl, 
                AccessControlType.Allow
            )
        );
    }
    //so that now nobody from outside can pass any dumb object to it
    static void SetFileFolderPermissions(dynamic info, FileSystemAccessRule rule)
    {
        try
        {
            var security = info.GetAccessControl();
            security.AddAccessRule(rule);
            info.SetAccessControl(security);
        }
        catch
        {
            Console.WriteLine("Error.");
        }
    }
    public static void SetFolderPermissions(string path)
    {
        SetFileFolderPermissions
        (
            new DirectoryInfo(path), 
            new FileSystemAccessRule
            (
                "TestAccount",
                 FileSystemRights.FullControl,
                 InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                 PropagationFlags.NoPropagateInherit,
                 AccessControlType.Allow
            ));
    }
