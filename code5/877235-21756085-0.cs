    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
    message.To.Add("admin@google.com");
    message.Subject = "Hello";
    message.From = new System.Net.Mail.MailAddress("admin@google.com");
    message.Body = "Hello world.";
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("host_name_defined_in_web_config");
    smtp.Send(message);
