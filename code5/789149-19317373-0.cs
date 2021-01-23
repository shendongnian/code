    public void TabPage1Permission(frmMain formMain, profile myProfile)
    {
        if (myProfile.Equals(profile.Visitor))
        {
            formMain.tabControl.TabPages.Remove(formMain.TabPage1);
        }
        else
        {
            formMain.tabControl.TabPages.Add(formMain.TabPage1);
        }
    }
