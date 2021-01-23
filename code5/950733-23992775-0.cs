     System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.To.Add(ToEmail);
        message.Subject = Subject;
        message.From = new System.Net.Mail.MailAddress(FromEmail);
        message.Body = Message;
        System.Net.Mail.SmtpClient smtpAddress = new System.Net.Mail.SmtpClient("IP");
        smtpAddress.Send(message);
