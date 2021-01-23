	Application  olApp = new Application();
	NameSpace olNS = olApp.GetNamespace("MAPI");
	MAPIFolder oFolder = olNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
	Items items = oFolder.Items;
	items.Sort("[ReceivedTime]");
	var subject = items.GetLast().Subject;
