    private void testClickToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
        if (menuItem != null)
        {
            ContextMenuStrip menu = menuItem.Owner as ContextMenuStrip;
            if (menu != null)
            {
                // dataElement is your Data for which ContextMenu was opened
                Data dataElement = menu.SourceControl as Data;
            }
        }
    }
