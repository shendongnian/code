    Mandrill.EmailMessage message = new Mandrill.EmailMessage();
    message.from_email = _setting.UserName;
    message.from_name = "Whatever";
    message.html = body;
    message.subject = subject;
    message.to = new List<Mandrill.EmailAddress>()
    {
        new Mandrill.EmailAddress(to, toDisplayName)
    };
    Mandrill.MandrillApi mandrillApi = new Mandrill.MandrillApi(_setting.Password, false);
    var results = mandrillApi.SendMessage(message);
    foreach (var result in results)
    {
          if (result.Status != Mandrill.EmailResultStatus.Sent)
               LogManager.Current.LogError(result.Email, "", "", "", null, string.Format("Email failed to send: {0}", result.RejectReason));
    }
