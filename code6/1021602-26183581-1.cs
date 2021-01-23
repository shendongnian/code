    public bool SendMail(string from, string to, string subject, string htmlContent, string plainContent)
    {
        //Email sending code - could be replaced by 3rd party mail sending API, etc.
        MailMessage mail = new MailMessage(from, to);
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Host = "smtp.google.com";
        mail.Subject = subject;
        mail.Body = htmlContent;
        client.Send(mail);
    }
