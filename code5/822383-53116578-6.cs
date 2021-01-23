    int port = 587;
    string host = "smtp.office365.com";
    string username = "smtp.out@mail.com";
    string password = "password";
    string mailFrom = "noreply@mail.com";
    string mailTo = "to@mail.com";
    string mailTitle = "Testtitle";
    string mailMessage = "Testmessage";
    using (SmtpClient client = new SmtpClient())
    {
        MailAddress from = new MailAddress(mailFrom);
        MailMessage message = new MailMessage
        {
            From = from
        };
        message.To.Add(mailTo);
        message.Subject = mailTitle;
        message.Body = mailMessage;
        message.IsBodyHtml = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Host = host;
        client.Port = port;
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential
        {
            UserName = username,
            Password = password
        }; 
        client.Send(message);
    }
    
