    private void myButton_Click(object sender, EventArgs e)
    {
        if (checkIfNumericalValue() && testIfTextBoxOnesMinimumIsMet(Convert.ToInt32(txtBoxOne.Text)) && testIfTextBoxTwosMinimumIsMet(Convert.ToInt32(txtBoxTwo.Text)))
        {
            displayResultToUser();
            resetOrClose();
        }
    }
    public bool testIfTextBoxOnesMinimumIsMet(int length)
    {
        if (length < 3)
        {
            MessageBox.Show("length must be greater than 3 metres");
            return false;
        }
        return true;
    }
