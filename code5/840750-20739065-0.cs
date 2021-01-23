    private void tabsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
        ...
        //create a menu item
        ToolStripMenuItem menu = new ToolStripMenuItem(t.Text);
        //Associate a tab index with a menu item
        menu.Tag = t.TabIndex;
        ...
    }
    private void menu_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem menu = (ToolStripMenuItem)sender;
        //Use a tab index associated with a menu item to select a tab
        tabEditor.SelectedIndex = (int)menu.Tag;
    }
