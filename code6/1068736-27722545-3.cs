    private void Equals_Click(object sender, EventArgs e)
    {
        // Remove the operator from the value we want to process.
        // It is expected this will be at the end.
        var userValue = textDisplay.Text;
        if (userValue.EndsWith(theOperator))
        {
            userValue = userValue.Substring(0, userValue.Length - theOperator.Length).Trim();
        }
        // Test for valid input.
        // Test our "userValue" variable which has the pending operator removed.
        double value;
        if (!double.TryParse(userValue, out value))
        {
            // Invalid input.
            // Alert the user and then exit this method.
            MessageBox.Show("A number was not entered.");
            return;
        }
        // If we get here, the "value" variable is a valid number.
        // Use it for calculations.
        ...
        
