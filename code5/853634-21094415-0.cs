    private bool formValidation(string text)
    {
        int number;
    
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Please enter a first name");
        }
        else if (!Int32.TryParse(text , out number))
        {
            MessageBox.Show("No numbers allowed for their first name");
        }
    
        return true;
    }
