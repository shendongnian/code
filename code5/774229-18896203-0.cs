    private void packetTextBox_TextChanged(object sender, EventArgs e)
    {
        string oldValue = (sender as TextBox).Text.Trim();
        string newValue = "";
    
        // IF there are more than 2 characters in oldValue:
        //     Move 2 chars from oldValue to newValue, and add a space to newValue
        //     Remove the first 2 chars from oldValue
        // ELSE
        //     Just append oldValue to newValue
        //     Make oldValue empty
        // REPEAT as long as oldValue is not empty
    
        (sender as TextBox).Text = newValue;
        
    }
