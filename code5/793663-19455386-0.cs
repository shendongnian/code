    public static void SetFileFolderPermissions(dynamic info)
    {
        if (!(info is FileInfo) || !(info is DirectoryInfo))
            throw new explosion;
        try
        {
            var security = info.GetAccessControl();
            security.AddAccessRule(new FileSystemAccessRule(...));
            info.SetAccessControl(security);
        }
        catch
        {
            Console.WriteLine("Error.");
        }
    }
