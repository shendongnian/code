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
        foreach (Control formControl in this.Controls)
        {
            // Find the groupbox control by name
            if (formControl.Name != "groupBox1") continue;
            // We found the group box, so loop through every control in it
            foreach (Control groupBoxControl in formControl.Controls)
            {
                // Try to cast the control to a TextBox.
                var textBoxControl = groupBoxControl as TextBox;
                // If the cast fails, move on to the next one...
                if (textBoxControl == null) continue;
                // Now we have one a textbox control, so see if the
                // textBoxNames array contains the name of this text box.
                if (textBoxNames.Contains(textBoxControl.Name,
                    StringComparer.OrdinalIgnoreCase))
                {
                    // We found a match, so set the backcolor based on Text property
                    if (textBoxControl.Text.Trim() == "")
                    {
                        textBoxControl.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        textBoxControl.BackColor = Color.White;
                    }
                }
            }
            // Since we found the control we were looking for, we can stop looking
            break;
        }
    }
