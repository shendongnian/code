    // Button
    private void myButton_Click(object sender, EventArgs e)
    {
        try
        {
            checkIfNumericalValue();
            testIfTextBoxOnesMinimumIsMet();
            testIfTextBoxTwosMinimumIsMet();
            displayResultToUser();
            resetOrClose();
        }
        catch (ArgumentException ex)
        {
            // The error message we defined at the exception we threw
            MessageBox.Show(ex.Message);
        }
    }
    // Textbox One
    public void testIfTextBoxOnesMinimumIsMet() 
    {
        if (length < 3) 
        {
            throw new ArgumentException("Length must be greater than 3 meters.");
        }
    }
