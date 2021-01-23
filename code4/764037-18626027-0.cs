    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        int countOfNumbers = 0;
        foreach(char c in textBox1.Text)
        {
            if(Char.IsDigit(c))
            {
                countOfNumbers += 1;
            }
        }
        // Display a MsgBox asking the user to save changes or abort. 
        MessageBox.Show("Number of numbers in text box is: " + countOfNumbers.ToString());
    }
