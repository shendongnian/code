    private void btn_Click(object sender, EventArgs e)
    {
        // This is the button which was clicked.
        var button = (Button)sender;
        var buttonName = button.Name;
        // Do some stuff.
    
        // To detect certain mouse click events, cast e as a MouseClick.
        MouseEventArgs mouseEvents = (MouseEventArgs)e;
    
        // Now use the mouseEvents object to handle specific events based on the button clicked.
        if (mouseEvents.Button == MouseButtons.Right)
        {
            // Right button clicked.
        }
        else if (mouseEvents.Button == MouseButtons.Left)
        {
            // Left button clicked.
        }
    }
