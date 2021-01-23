    // Global scope
    bool errorsFound = false;
    // Button
    private void myButton_Click(object sender, EventArgs e)
    {
        checkIfNumericalValue();
        testIfTextBoxOnesMinimumIsMet();
        testIfTextBoxTwosMinimumIsMet();
        if (!errorsFound)
        {
            displayResultToUser();
        }
        else
        {
            // Reset errors found variable so they can try again
            errorsFound = false;
        }
        resetOrClose();  // I'm not sure if this should happen regardless of errors?
    }
    // Textbox One
    public void testIfTextBoxOnesMinimumIsMet() 
    {
        if (length < 3) 
        {
            MessageBox.Show("length must be greater than 3 metres");
            errorsFound = true;
        }
    }
