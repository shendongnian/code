    // Button
    private void myButton_Click(object sender, EventArgs e)
    {
        checkIfNumericalValue();
        if (length < 3) 
        {
            MessageBox.Show("Length must be greater than 3 meters.");
            return;
        }
        testIfTextBoxTwosMinimumIsMet();
        displayResultToUser();
        resetOrClose();
    }
