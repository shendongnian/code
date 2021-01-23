    private void txt_checkemail_TextChanged(object sender, EventArgs e)
    {
       var isValid = ValidateEmail(txt_checkemail.Text);
       if (isValid)
       {
           MessageBox.Show("The emailadress you've entered is valid!");
       }
       else
       {
           MessageBox.Show("The emailadress you've entered is NOT valid!");
       }
    }
    
    private bool ValidateEmail(object valueToCheck)
    {
        //execute query on the database to check if the value entered in the textbox is valid.
    }
