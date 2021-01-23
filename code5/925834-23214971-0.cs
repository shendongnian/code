    MailMessage mailMessage= new MailMessage();
    
    mailMessage.From = new MailAddress("sender email address goes here");
 
    // Loop all your clients addresses
    foreach (string address in addresses)
    {
        mailMessage.To.Add(address);    
    }
    
    mailMessage.Subject = "your message subject goes here";
    mailMessage.Body = "your message body goes here";
    MemoryStream memoryStream = new MemoryStream(binaryFile);
    mailMessage.Attachments.Add( new Attachment( memoryStream, filename , MediaTypeNames.Application.Pdf ));
    
    SmtpClient smtpClient = new SmtpClient();
    smtpClient.Send(mailMessage);
