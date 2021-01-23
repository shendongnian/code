    protected void Page_Load(object sender, EventArgs e)
    {
        string path = Server.MapPath("theFileLocation");
        RemoveFileSecurity(path, @"App Pool Identity", FileSystemRights.FullControl, AccessControlType.Deny);
        AddFileSecurity(path, @"App Pool Identity", FileSystemRights.FullControl, AccessControlType.Allow);
    
        FileAttributes a = File.GetAttributes(path);
        a = RemoveAttribute(a, FileAttributes.ReadOnly);
        File.SetAttributes(path, FileAttributes.Normal);
    }
    
    private FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
    {
        return attributes & ~attributesToRemove;
    }
    
    
    private void AddFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
    {
        FileSecurity fSecurity = File.GetAccessControl(fileName);
        fSecurity.AddAccessRule(new FileSystemAccessRule(account, rights, controlType));
        File.SetAccessControl(fileName, fSecurity);
    }
    
    private void RemoveFileSecurity(string fileName, string account, FileSystemRights rights, AccessControlType controlType)
    {
        FileSecurity fSecurity = File.GetAccessControl(fileName);
        fSecurity.RemoveAccessRule(new FileSystemAccessRule(account, rights, controlType));
        File.SetAccessControl(fileName, fSecurity);
    }
