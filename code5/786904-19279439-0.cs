        MailMessage emailMessage = new MailMessage();
        emailMessage.From = new MailAddress("administrator@gmail.com", "Administrator");
        emailMessage.To.Add(new MailAddress(email));
        emailMessage.Subject = subject;
        emailMessage.Body = message;
        emailMessage.IsBodyHtml = true;
        emailMessage.Priority = MailPriority.Normal;
        SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
        MailClient.EnableSsl = true;
        MailClient.Credentials = new System.Net.NetworkCredential("administrator@gmail.com", "p@ssw0rd123");
        MailClient.Send(emailMessage);
    }
