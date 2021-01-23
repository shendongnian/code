    public class Permissions
    {
        public void addPermissions(string dirName, string username)
        {
            changePermissions(dirName, username, AccessControlType.Allow);
        }
    
        public void revokePermissions(string dirName, string username)
        {
            changePermissions(dirName, username, AccessControlType.Deny);
        }
    
        private void changePermissions(string dirName, string username, AccessControlType newPermission)
        {
            DirectoryInfo myDirectoryInfo = new DirectoryInfo(dirName);
    
            DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
    
            string user = System.Environment.UserDomainName + "\\" + username;
    
            myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(
                user, 
                FileSystemRights.Read | FileSystemRights.Write | FileSystemRights.ExecuteFile | FileSystemRights.Delete, 
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, 
                PropagationFlags.InheritOnly, 
                newPermission
            ));
    
            myDirectoryInfo.SetAccessControl(myDirectorySecurity);
        }
    }
