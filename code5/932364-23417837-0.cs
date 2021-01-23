    public static void SendNotificationEmail(Settings setting)
    {
         // Loop through our generic list.
         foreach(string email in setting.To)
         {
              // Assign our email parameters to the message.
              MailMessage message = new MailMessage(setting.From, email, setting.Subject, setting.Body);
    
              //Build Our Smtp Client
              SmtpClient client = new SmtpClient();
              client.Host = setting.SmtpServer;
              client.Port = setting.Port;
              client.Timeout = setting.Timeout;
              client.DeliveryMethod = SmtpDeliveryMethod.Network;
              client.UseDefaultCredentials = false;
              client.Credentials = new NetworkCredential(setting.Username, setting.Password);
         }
    }
