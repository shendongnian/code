    MailMessage message = new MailMessage();
    message.From = new MailAddress("your email address");
    message.To.Add(new MailAddress("the target email address"));
    message.Subject = "...";
    message.Body = content;
    
    var client = new SmtpClient();
    client.Send(message);
