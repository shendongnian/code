    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        // Attempt to cast the sender to CheckBox type
        CheckBox theCheckBox = sender as CheckBox;
        // Check to see if check box was found before we try to use it
        if(theCheckBox != null)
        {
            // Get the grid view row object
            GridViewRow theGridViewRow = theCheckBox.Parent.Parent as GridViewRow;
            // Check to see if grid view row was found before we try to use it
            if(theGridViewRow != null)
            {
                // Is the check box checked or not?
                if(theCheckBox.Checked)
                {
                    // Yes, it is checked
                    // Find amount text box and perform logic
                    TextBox theAmountTextBox = theGridViewRow.FindControl("TextBox7") as TextBox;
                    // Check to see if amount text box was found before we try to use it
                    if(theAmountTextBox != null)
                    {
                        // Do logic here to update amount text box value
                    }
                }
                else
                {
                    // No, it is not checked
                    // Do something here if need be; otherwise get rid of else
                }
            }
        }
    }
