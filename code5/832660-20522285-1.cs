    public bool SendEmailMessage(string template, object viewModel, string to, string @from, string subject, params string[] replyToAddresses)
        {
           var compiledTemplate = LoadTemplate(template, viewModel);
           try
           {
             SendEmail(from, to, subject, compiledTemplate, from, null, replyToAddresses);
             return true;
           }
           catch(Exception ex)
           {
             return false;
           }                         
        }
    
     public string LoadTemplate(string template, object viewModel)
            {
                var templateContent = AttemptLoadEmailTemplate(template);
                var compiledTemplate = Razor.Parse(templateContent, viewModel);
    
                return compiledTemplate;
            }
    
        private string AttemptLoadEmailTemplate(string name)
        {
            if (File.Exists(name))
            {
                var templateText = File.ReadAllText(name);
                return templateText;
            }
    
            var templateName = string.Format("~/Data/EmailTemplates/{0}.html", name); //Just put your path to a scpecific template
            var emailTemplate = pathResolver.ResolveServerPath(templateName);
    
            if (File.Exists(emailTemplate))
            {
                var templateText = File.ReadAllText(emailTemplate);
                return templateText;
            }
    
            return null;
        }
    
        private void SendEmail(string from, string to, string subject, string body, string replyTo, List<Attachment> attachedFiles, params string[] replyToAddresses)
                {
                    replyTo = replyTo ?? from;
                    attachedFiles = attachedFiles ?? new List<Attachment>();
                    
                    var message = new MailMessage(from, to, subject, body);
                    message.ReplyToList.Add(replyTo);
        
                    foreach (var attachedFile in attachedFiles)
                        message.Attachments.Add(attachedFile);
        
                    smtpClient.SendAsync(email, null);
                }
