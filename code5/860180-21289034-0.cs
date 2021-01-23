    DirectoryInfo directoryInfo = new DirectoryInfo(session["..."]);
    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
    SecurityIdentifier localService = new SecurityIdentifier(WellKnownSidType.LocalServiceSid, null);
    FileSystemAccessRule directoryAccessRule = new FileSystemAccessRule(localService, FileSystemRights.FullControl, AccessControlType.Allow);
    directorySecurity.AddAccessRule(directoryAccessRule);
    directoryInfo.SetAccessControl(directorySecurity);
