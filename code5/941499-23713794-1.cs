    public Task<IResultDescription> SendEmailAsync(MailMessage message, IResultDescription rd)
    {
      using (SmtpClient client = new SmtpClient())
      using (message)
      {
        client.Host = SmtpServer;
        client.Port = SmtpServerPort;
        client.Credentials = new NetworkCredential(SmtpServerUsername, SmtpServerPassword);
        client.EnableSsl = true;
        if (AppSettings.IsInTestMode)
        {
          Log.Info("Test mode check: Removing all emails and replace to test");
          message.To.Clear();
          foreach (var email in AppSettings.DefaultTestEmail)
          {
            message.To.Add(new MailAddress(email));
          }
        }
        client.Timeout = 10;
        Log.Info("Sending Email to" + message.To.FirstOrDefault());
        try
        {
          await client.SendAsync(message);
          rd.Success = true;
        }
        catch (Exception e)
        {
          Log.Error("Email not send");
          rd.Success = false;
          if (rd.Errors == null)
          {
            IList<string> errors = new List<string>();
            errors.Add(e.Message);
            rd.Errors = errors;
          }
          else
          {
            rd.Errors.Add(e.Message);
          }
        }
        return rd;
      }
    }
