    public void Send(string from, string to, string subject, IDictionary<string, string> replacementTokens, string templateId)
    {
      var mail = new SendGridMessage
      {
        From = new MailAddress(from)
      };
      mail.AddTo(to);
      mail.Subject = subject;
      // NOTE: Text/Html and EnableTemplate HTML are not really used if a TemplateId is specified
      mail.Text = string.Empty;
      mail.Html = "<p></p>";
      mail.EnableTemplate("<%body%>");
      mail.EnableTemplateEngine(templateId);
      // Add each replacement token
      foreach (var key in replacementTokens.Keys)
      {
        mail.AddSubstitution(
          key,
          new List<string>
            {
              replacementTokens[key]
            });
      }
      var transportWeb = new Web("THE_AUTH_KEY");
      var result = transportWeb.DeliverAsync(mail);
    }
