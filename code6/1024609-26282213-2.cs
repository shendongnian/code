    private void txtbxRecurEveryXWeeks_LostFocus(object sender, EventArgs e)
    {
        int value;
        if(!string.IsNullOrWhitespace(txtbxRecurEveryXWeeks.Text) 
            && int.TryParse(txtbxRecurEveryXWeeks.Text, out value) 
            && value > 0)
        {
            //Do something like clear the textbox value
        }
    }
