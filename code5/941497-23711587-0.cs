    public Task SendMailToAllUsers(string content, string title)
        {
            var users = UserService.GetAllUsers();
            var mailTemplates =  users.Result.AsParallel().Select(user =>
            {
    
                var mailTemplate = new MastersMailTemplate(user);
                mailTemplate.HtmlEmailTemplate = content;
                mailTemplate.Subject = title;
                mailTemplate.From = _fromEmail;
    
                // Await the result of the lambda expression
                return Task.Factory.StartNew(() => await MailProvider.SendEmailAsync(mailTemplate.CreateMailMessage(), new ResultDescription()).ConfigureAwait(false));
            }).ToArray();
    
            return Task.WhenAll(mailTemplates);
        }
    
