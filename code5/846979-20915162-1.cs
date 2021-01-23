    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.To.Add("luckyperson@online.microsoft.com");
    message.Subject = "This is the Subject line";
    message.From = new System.Net.Mail.MailAddress("yourmailuser@yourhost.com",25);
    message.Body = "This is the message body";
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
    // if you need user/pass login
    client.Credentials = new NetworkCredential("username","password");
    smtp.Send(message);
