    // Button
    private void myButton_Click(object sender, EventArgs e)
    {
        bool noErrors = 
            isNumericalValue() &&
            textBoxOnesMinimumIsMet() &&
            textBoxTwosMinimumIsMet();
        if (noErrors)
        {
            displayResultToUser();
            resetOrClose();  // I'm not sure if this should happen regardless of errors?
        }        
    }
    // Textbox One
    public bool textBoxOnesMinimumIsMet() 
    {
        if (length < 3) 
        {
            MessageBox.Show("length must be greater than 3 metres");
            return false;
        }
    
        return true;
    }
