    //If both email and password are not empty
    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
    {
        //if both email and password math the re entry
        if (txtBoxEmail.Text == txtBoxConfirmEmail.Text &&
            txtBoxPassword.Text == txtBoxConfirmPassword.Text)
        {
            //execute the code to open the new form
            this.Hide();
            frmBilling secondForm = new frmBilling();
            secondForm.Show();
        }
    }
