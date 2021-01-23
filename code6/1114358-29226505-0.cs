    using System.IO;
    using System.Security.AccessControl; 
        
         public static bool CheckWritePermissionOnDir(string path)
            {
                var writeAllow = false;
                var writeDeny = false;
                var accessControlList = Directory.GetAccessControl(path); Control
                if (accessControlList == null)
                    return false;
                var accessRules = accessControlList.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                if (accessRules == null)
                    return false;
        
                foreach (FileSystemAccessRule rule in accessRules)
                {
                    if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
                        continue;
        
                    if (rule.AccessControlType == AccessControlType.Allow)
                        writeAllow = true;
                    else if (rule.AccessControlType == AccessControlType.Deny)
                        writeDeny = true;
                }
        
                return writeAllow && !writeDeny;
            }
