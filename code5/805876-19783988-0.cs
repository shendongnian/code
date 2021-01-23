     public static void SetAccessRule(string directory)
        {
            System.Security.AccessControl.DirectorySecurity Security = System.IO.Directory.GetAccessControl(directory);
            FileSystemAccessRule accountAllow = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
            Security.AddAccessRule(accountAllow);
        }
