    private void card_No_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(card_No.Text))
        {
            if (Regex.Matches(card_No.Text, @"(-|\d)").Count != card_No.Text.Length)
            {
                //pasted an invalid value
                MessageBox.Show("Invalid value entered");
            }
        }
    }
   
