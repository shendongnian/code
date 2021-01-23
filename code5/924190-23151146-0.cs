    public string[] selected()
    {
        string strTemp = "";
        for (int i = 0; i < chbindustry.Items.Count - 1; i++)
        {
            if (chbindustry.Items[i].Selected)
            {
                strTemp += chbindustry.Items[i].Text.ToString() + ",";
            }
        }
        string[] selecteditems = strTemp.Split(','); 
        return selecteditems;
    }
.........
.........
    foreach (string s in subdirectoryEntries)
    {
        if (!string.IsNullOrEmpty(s))
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
