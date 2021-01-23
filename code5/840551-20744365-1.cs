    ContextMenu cm = new ContextMenu();
    MenuItem mi = new MenuItem()
    {
        Text = "click me"
    };
    mi.Click += new EventHandler(mi_Click);
    cm.MenuItems.Add(mi);
    cm.Name = "name";
    void tsi_Click(object sender, EventArgs e)
    {
        ToolStripItem item = (sender as ToolStripItem);
        if (item != null)
        {
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;
            if (owner != null)
            {
                 string a = owner.Name;
            }
        }
    }
