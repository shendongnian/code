    SmtpClient smtpClient = new SmtpClient("smtp.mail.yahoo.com", 465);
    smtpClient.Credentials = new System.Net.NetworkCredential("hsbanga@yahoo.com", "secret");
    smtpClient.EnableSsl = true;
    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    MailMessage mail = new MailMessage();
    smtpClient.Send(mail);
 
