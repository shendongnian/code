    sr = new StreamReader(filename.aspx);
    EmailBody = sr.ReadToEnd();
    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(hostname);
    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(parameters);
    message.IsBodyHtml = true;
    client.Send(message);
