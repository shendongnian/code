    private void HighlightEmptyFields()
    {
        // Create a list of all the text box names that we want to examine
        var textBoxNames = new List<string>
        {
            "activity_TitleTextBox", "act_Title2TextBox", "kid_NotesTextBox", 
            "review_AdultTextBox", "phoneTextBox", "addressTextBox", "cityTextBox", 
            "websiteTextBox", "weblink_TextTextBox", "hoursTextBox", "admissionTextBox"
        };
    
        // Loop through every control on the form
        foreach (var control in this.Controls)
        {
            // Try to cast the control to a TextBox.
            var textBoxControl = control as TextBox;
    
            // If the cast fails, move on to the next one...
            if (textBoxControl == null) continue;
    
            // Now we have a textbox control, so see if our
            // textBoxNames array contains the name of this text box.
            if (textBoxNames.Contains(textBoxControl.Name))
            {
                // We found a match, so set the backcolor based on Text property
                if (string.IsNullOrWhiteSpace(textBoxControl.Text))
                {
                    textBoxControl.BackColor = Color.LightYellow;
                }
                else
                {
                    textBoxControl.BackColor = DefaultBackColor;
                }
            }
        }
    }
