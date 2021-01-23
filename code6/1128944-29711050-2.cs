    int input; 
    if (e.KeyCode == Keys.Enter)
    {
        if (int.TryParse(tbInput.Text, out input) && input >= MIN && input <= MAX)
        {
            ...
        }
        else
        {
            MessageBox.Show("Please enter an integer between 1 and 10");
        }
    }
