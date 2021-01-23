    string[] selecteditems = selected();
    foreach (string s in subdirectoryEntries)
    {
        if (!string.IsNullOrEmpty(s) && selecteditems.Contains(s)) //Folder is selected in ListItem
        {
            DirectoryInfo d = new DirectoryInfo(s);
            for (int i = 1; i <= d.GetFiles().Length / 3; i++)
            {
                selected();
                Page.ClientScript.RegisterArrayDeclaration("ImgPaths", "'" + "BusinessCards/" + s.Remove(0, s.LastIndexOf('\\') + 1) + "/" + i + ".jpg'");
                Page.ClientScript.RegisterArrayDeclaration("refs", "'" + "DesignBCs.aspx?img=BusinessCards/" + s.Remove(0, s.LastIndexOf('\\') + 1) + "/" + i + "&Side=2'");
            }
        }
    }
