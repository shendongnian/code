    // Determines the scope the new cursor will have. 
    // 
    // If the RadioButton rbScopeElement is selected, then the cursor 
    // will only change on the display element. 
    //  
    // If the Radiobutton rbScopeApplication is selected, then the cursor 
    // will be changed for the entire application 
    // 
    private void CursorScopeSelected(object sender, RoutedEventArgs e)
    {
        RadioButton source = e.Source as RadioButton;
    
        if (source != null)
        {
            if (source.Name == "rbScopeElement")
            {
                // Setting the element only scope flag to true
                cursorScopeElementOnly = true;
                // Clearing out the OverrideCursor.  
                Mouse.OverrideCursor = null;
            }
            if (source.Name == "rbScopeApplication")
            {
               // Setting the element only scope flag to false
               cursorScopeElementOnly = false;
    
               // Forcing the cursor for all elements. 
               Mouse.OverrideCursor = DisplayArea.Cursor;
            }
        }
    }
