    public async Task SendNotification(string SendTo,string[] cc,string subject,string body,string path)
        {             
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress(SendTo));
            foreach (string ccmail in cc)
                {
                    message.CC.Add(new MailAddress(ccmail));
                }
            message.Subject = subject;
            message.Body =body;
            message.Attachments.Add(new Attachment(path));
            //message.Attachments.Add(a);
            try {
                 message.Priority = MailPriority.High;
                message.IsBodyHtml = true;
                await Task.Yield();
                client.Send(message);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
     }
