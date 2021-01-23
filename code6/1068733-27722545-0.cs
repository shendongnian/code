    private void Equals_Click(object sender, EventArgs e)
    {
        // Test for valid input.
        double value;
        if (!double.TryParse(textDisplay.Text, out value)
        {
            // Invalid input.
            // Alert the user and then exit this method.
            MessageBox.Show("A number was not entered.");
            return;
        }
        // If we get here, the "value" variable is a valid number.
        // Use it for calculations.
        ...
        
