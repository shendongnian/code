    public async Task SendMailToAllUsersAsync(string content, string title)
    {
      var users = await UserService.GetAllUsersAsync();
      var mailTemplates = users.AsParallel().Select(user =>
      {
        var mailTemplate = new MastersMailTemplate(user);
        mailTemplate.HtmlEmailTemplate = content;
        mailTemplate.Subject = title;
        mailTemplate.From = _fromEmail;
        return MailProvider.SendEmailAsync(mailTemplate.CreateMailMessage());
      }).ToArray();
      return await Task.WhenAll(mailTemplates);
    }
