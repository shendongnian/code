    // creating the attachment
    System.Net.Mail.Attachment inline = new System.Net.Mail.Attachment(@"c:\\test.png");
    inline.ContentDisposition.Inline = true;
    // sending the message
    MailMessage email = new MailMessage();
    // set the information of the message (subject, body ecc...)
    
    // send the message
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("localhost");
    smtp.Send(email);
    email.Dispose();
