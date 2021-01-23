    public void TabPage1Permission(frmMain formMain, profile myProfile, int index)
    {
        if (myProfile.Equals(profile.Visitor))
        {
            formMain.tabControl.TabPages.Remove(formMain.TabPage1);
        }
        else
        {
            formMain.tabControl.TabPages.Insert(index, formMain.TabPage1);
        }
    }
