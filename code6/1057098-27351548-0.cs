    if (! txtBoxEmail.Text.Equals( txtBoxConfirmEmail.Text))
    {
        lblEmailError.Text = ("Email reentry does not match. Please reenter.");
    }
    
    if (! txtBoxPassword.Text.Equals( txtBoxConfirmPassword.Text))
    {
        lblPasswordError.Text = ("Password reentry does not match. Please reenter.");
    }
