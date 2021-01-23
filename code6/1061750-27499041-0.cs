    private void MenuViewDetails_Click(object sender, EventArgs e)    
    {    
        // Try to cast the sender to a MenuItem    
        MenuItem menuItem = sender as MenuItem;    
        if (menuItem != null)    
        {    
            // Retrieve the ContextMenu that contains this MenuItem    
            ContextMenu menu = menuItem.GetContextMenu();    
            // Get the control that is displaying this context menu    
            Control sourceControl = menu.SourceControl;    
        }
    }
