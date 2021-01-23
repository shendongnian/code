    bool validationStatus = default(bool);
    
    if (string.IsNullOrEmpty(email))
    {
        lblRequirementsError.Text = ("All required fields have not been filled.");
        validationStatus  = true;
    }
    
    if (txtBoxEmail.Text != txtBoxConfirmEmail.Text)
    {
        lblEmailError.Text = ("Email reentry does not match. Please reenter.");
        validationStatus  = true;
    }
    
    if (txtBoxPassword.Text != txtBoxConfirmPassword.Text)
    {
        lblPasswordError.Text = ("Password reentry does not match. Please reenter.");
        validationStatus  = true;
    }
    
    if(!validationStatus)
    {
       Hide();
       frmBilling secondForm = new frmBilling();
       secondForm.Show();
    }
