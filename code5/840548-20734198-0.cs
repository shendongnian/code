    void mi_Click(object sender, EventArgs e)
    {
        // try to convert your "sender" to a MenuItem
        MenuItem item = (sender as MenuItem);
        if (item != null) 
        {
            // if successful - get the MenuItem's "Parent" -> that should be your "ContextMenu"
            ContextMenu ctxMenu = item.Parent as ContextMenu;
            if(ctxMenu != null)
            {
                // if that's successful, the context menu's "SourceControl"
                // should tell you which control the menu was opened over 
                Control controlThatCausedMenuItemToBeClicked = ctxMenu.SourceControl;
            }
        }
    }
