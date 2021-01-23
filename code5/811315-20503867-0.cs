        public static void sendMail(string msg)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(emailFrom);
            smtpClient.Host = smtpHost;
            message.From = fromAddress;
            message.Subject = "Test Email";
            message.IsBodyHtml = true;
            message.Body = msg;
            message.To.Add(emailTo);
            message.Priority = MailPriority.High;
            smtpClient.Send(message);
        }
    
