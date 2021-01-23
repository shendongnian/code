    using System.IO;
    using System.IO;
    using System.Security.AccessControl;
    using System.Security.Principal;
    //Get Currently Applied Access Control
    FileSecurity fileS = File.GetAccessControl(filepath);
        
    //Update it, Grant Current User Full Control
    SecurityIdentifier cu = WindowsIdentity.GetCurrent().User;
    fileS.SetOwner(cu);
    fileS.SetAccessRule(new FileSystemAccessRule(cu, FileSystemRights.FullControl, AccessControlType.Allow));
        
    //Update the Access Control on the File
    File.SetAccessControl(filepath, fileS);
           
    File.SetAttributes(filePath, FileAttributes.Normal);
    File.Delete(filePath);
