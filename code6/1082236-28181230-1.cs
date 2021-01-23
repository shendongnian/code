	using System.Security.AccessControl;
	//...
	string dir = @"C:\MyTestFolder";
    //If you update the access rules here, it doesn't work
	Directory.CreateDirectory(dir);
    //Now that the folder has been created...
    DirectorySecurity dirSec = Directory.GetAccessControl(dir);
    dirSec.AddAccessRule(
		new FileSystemAccessRule(@"contoso.com\myuser",
			FileSystemRights.FullControl,
			InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
			PropagationFlags.None,
			AccessControlType.Allow));
    dirSec.SetAccessRuleProtection(false, true);
    Directory.SetAccessControl(dir, dirSec);
