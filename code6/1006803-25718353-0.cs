    private void mnuDatabase1_Click(object sender, ...)
    {
        ToolStripMenuItem MyMenuItem = (ToolStripMenuItem)sender;
        ToolStripMenuItem parent = MyMenuItem.OwnerItem;
        if (parent.Name == "mnuAdd")
            //Add Menu
        else if (parent.Name == "mnuEdit")
            //Edit Menu
        if (parent.Name == "mnuDelete")
            //Delete Menu
    }
