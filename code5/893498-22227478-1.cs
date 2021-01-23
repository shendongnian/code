     DirectoryInfo dInfo = new DirectoryInfo(dir);
     FileSystemAccessRule acl = new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow);
     if (dInfo.Exists)
     {
         DirectorySecurity ds = dInfo.GetAccessControl();
         ds.AddAccessRule(acl);
         dInfo.SetAccessControl(ds);
     }
