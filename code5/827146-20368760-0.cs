    protected void checkbox_CheckChanged(object sender, EventArgs e) 
    {
        CheckBox theCheckBox = sender as CheckBox;
        // Make sure the cast to check box worked before we try to use it
        if(theCheckBox != null)
        {
            LinkButton theLinkButton = theCheckBox.Parent.FindControl("lnkpro1") as LinkButton;
            // Verify that the link button was found before we try to use it
            if(theLinkButton != null)
            {
                // Get the text value from the link button in the same row 
                // as the check box checked changed
                string theLinkButtonText = theLinkButton.Text;
                // Do something with text value here
            }
        }
    }
