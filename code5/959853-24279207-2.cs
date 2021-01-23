    private bool ValidateContact()
    {
        int val;
        if (int.TryParse(textBox4.Text, out val))
        {
           return true;
        }
        else
        {
            return false;
        }
    }
