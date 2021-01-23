    protected void SendEmail()
    {
        string EmailAddress = "myemail@gmail.com";
        MailMessage mailMessage = new MailMessage(EmailAddress, EmailAddress);
        mailMessage.Subject = "This is a test email";
        mailMessage.Body = "This is a test email. Please reply if you receive it.";
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.Credentials = new System.Net.NetworkCredential()
        {
            UserName = EmailAddress,
            Password = "password"
        };
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Send(mailMessage);
    }
