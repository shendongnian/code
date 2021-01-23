    var mailMessage = new MailMessage();
    mailMessage.To.Add("yourEmail@hotmail.co.uk");
    mailMessage.From = new MailAddress("myEmail@hotmail.co.uk");
    mailMessage.Subject = "testing 2 ";
    mailMessage.Body = "Hello Mr. Aderson";
    mailMessage.IsBodyHtml = false;
    //this what you miss
        smptClient.Send(mailMessage);
    //
