    MailMessage message = new MailMessage();
    SmtpClient smtp = new SmtpClient();
    
    message.From = new MailAddress("EmailId");
    message.To.Add(new MailAddress("ReceiverEmailId"));
    message.Subject = "auto generated mail";
    message.Body = "Hello world";
    smtp.Port = 25;
    
    smtp.Host = "smtp.gmail.com";
    
    smtp.EnableSsl = true;
    smtp.UseDefaultCredentials = false;
    smtp.Credentials = new NetworkCredential("EmailId", "Password");
    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
    smtp.Send(message);
