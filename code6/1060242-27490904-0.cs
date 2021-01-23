    Outlook._NameSpace nSpace = app.GetNamespace("MAPI");
    Outlook.Stores theStore = nSpace.Stores;
    Folders subFolder = recip.Parent.Folders;    
    dynamic email;
    for(int i = 1; i<= subFolder.GetFirst().Folders["folderName"].Folders["subFolderName"].Items.Count; i++)
    {
        email = subFolder.GetFirst().Folders["folderName].Folders["subFolderName"].Items[i];
