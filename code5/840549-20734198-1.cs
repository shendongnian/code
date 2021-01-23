    void mi_Click(object sender, EventArgs e)
    {
        // try to convert your "sender" to a ToolStripItem
        ToolStripItem item = (sender as ToolStripItem);
        if (item != null) 
        {
            // if successful - get the MenuItem's "Parent" -> that should be your "ContextMenu"
            ContextMenuStrip ctxMenu = item.Owner as ContextMenuStrip;
            if(ctxMenu != null)
            {
                // if that's successful, the context menu's "SourceControl"
                // should tell you which control the menu was opened over 
                Control controlThatCausedMenuItemToBeClicked = ctxMenu.SourceControl;
                string controlsName = controlThatCausedMenuItemToBeClicked.Name;
            }
        }
    }
