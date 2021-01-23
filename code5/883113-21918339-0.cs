    void Send(IDictionary<string, string> emailDetails, string subject)
    {
      WebMail.SmtpServer = ConfigHelper.SmtpServer;
      WebMail.SmtpPort = ConfigHelper.SmtpPort;
      WebMail.UserName = ConfigHelper.EmailUserName;
      WebMail.From = ConfigHelper.EmailFrom;
      WebMail.Password = ConfigHelper.Password;
      emailDetails.ToList().ForEach( e =>
      { 
        WebMail.Send(e.Key,
            subject,
            e.Value);
      });
    }
