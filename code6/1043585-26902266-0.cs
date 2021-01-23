    public void SetAccess()
            {
                DirectoryInfo myDirectoryInfo = new DirectoryInfo(@"C:/Users/Trov/Desktop/Test");
    
                var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null); 
    
                DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
    
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(sid, FileSystemRights.Read, AccessControlType.Deny));
    
                myDirectoryInfo.SetAccessControl(myDirectorySecurity);
    
                this.Hide();
    
                this.Close();
            }
