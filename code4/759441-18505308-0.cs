    using (var client = new System.Net.Mail.SmtpClient("smtp.live.com", 25))
    {
        client.Credentials = new System.Net.NetworkCredential("example@hotmail.com", "******");
        client.EnableSsl = true;
  
        var from = new System.Net.Mail.MailAddress("example@hotmail.com", "Your name");
        var to = new System.Net.Mail.MailAddress("targetexample.com", "Receiver name");
  
        var message = new System.Net.Mail.MailMessage(from, to);
        message.Subject = "Test mail";
        message.Body = "Content";
        client.Send(message);
    }
