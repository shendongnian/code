    try
    {
        var mail = new MailAddress(emailTxt.Text);
        MessageBox.Show("Email Valid");
    }
    catch (FormatException)
    {
        MessageBox.Show("Email Invalid");
    }
