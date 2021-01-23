    protected void OnClickHandler(object sender, EventArgs e)
    {
        var theLinkButton = sender as LinkButton;
	
        // The as operator returns null if the cast fails
        // Check to see if link button exists before we try to use it
        if(theLinkButton != null)
        {
            // Check for CommandName from markup
            if(theLinkButton.CommandName = "EditName")
            {
                // Do logic here to edit name
            }
            // Other CommandName values could be handled here
        }
    }
