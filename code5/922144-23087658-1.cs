    using (var mm = new MailMessage())
    {
        try
        {
            mm.To.Add(emailTxt.Text);
            MessageBox.Show("Email Valid");
            ... rest of your code to send the email
        }
        catch (FormatException)
        {
            MessageBox.Show("Email Invalid");
        }
    }
