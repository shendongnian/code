    SmtpClient smtpClient = new SmtpClient();
    MailMessage mailMessage = new MailMessage();
    
    mailMessage.To.Add(new MailAddress("sender@mail.com"));
    mailMessage.Subject = "mailSubject";
    mailMessage.Body = "mailBody";
    
    smtpClient.Send(mailMessage);
