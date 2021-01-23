    using (var mm = new MailMessage())
    {
        try
        {
            mm.To.Add(emailTxt.Text);
            MessageBox.Show("Email Valid");
        }
        catch (FormatException)
        {
            MessageBox.Show("Email invalid");
        }
    }
