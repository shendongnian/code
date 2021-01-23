	var remoteControlObject = new ManagementPath
	{
		ClassName = "Win32_ComputerSystem",
		Server = oldName,
		Path = oldName + "\\root\\cimv2:Win32_ComputerSystem.Name='" + oldName + "'",
		NamespacePath = "\\\\" + oldName + "\\root\\cimv2"
	};
	string domain = accountWithPermissions.Domain;
	string user = accountWithPermissions.UserName;
	var conn = new ConnectionOptions
	{
		Authentication = AuthenticationLevel.PacketPrivacy,
		Username = domain + "\\" + accountWithPermissions.UserName,
		Password = accountWithPermissions.Password
	};
	var remoteScope = new ManagementScope(remoteControlObject, conn);
	var remoteSystem = new ManagementObject(remoteScope, remoteControlObject, null);
	try
	{
		ManagementBaseObject newRemoteSystemName = remoteSystem.GetMethodParameters("Rename");
		newRemoteSystemName.SetPropertyValue("Name", newName);
		newRemoteSystemName.SetPropertyValue("UserName", accountWithPermissions.UserName);
		newRemoteSystemName.SetPropertyValue("Password", accountWithPermissions.Password);
		ManagementBaseObject outParams = remoteSystem.InvokeMethod("Rename", newRemoteSystemName, null);
	}
	catch (Exception e)
	{
		this.Res.Inlines.Add(string.Format("Ошибка:\n" + e.Message + "\n"));
		this.Res.Inlines.Add(string.Format("Пробуем переименовать используя NETDOM\n"));
		bool restart = false;
		PowerNETDOM(oldName, newName, accountWithPermissions, restart);
	}
