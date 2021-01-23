        public void SetFileSecurity(String filePath, String domainName, String userName)
        {
            //get file info
            FileInfo fi = new FileInfo(filePath);
            //get security access
            FileSecurity fs = fi.GetAccessControl();
            //remove any inherited access
            fs.SetAccessRuleProtection(true, false);
            //get any special user access
            AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
            //remove any special access
            foreach (FileSystemAccessRule rule in rules)
                fs.RemoveAccessRule(rule);
            //add current user with full control.
            fs.AddAccessRule(new FileSystemAccessRule(domainName + "\\" + userName, FileSystemRights.FullControl, AccessControlType.Allow));
            //add all other users delete only permissions.
            fs.AddAccessRule(new FileSystemAccessRule("Authenticated Users", FileSystemRights.Delete, AccessControlType.Allow));
            //flush security access.
            File.SetAccessControl(filePath, fs);
        }
