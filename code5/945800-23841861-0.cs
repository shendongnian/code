     public static void SendEmail(string emailbody)
        {
          MailMessage mailMessage = new MailMessage("incoming email address", "receiver email address");
          mailMessage.Body = emailbody;
          mailMessage.Subject = "Feedback";
    
          SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net", 25);
          smtpClient.EnableSsl = false;
          smtpClient.Send(mailMessage);
        }
