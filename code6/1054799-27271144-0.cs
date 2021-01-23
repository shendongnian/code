    public void SendEmailWithGmail(string emailContent, string emailRecipients, string emailSubject)
        {
            var @from = _emailSendFrom;  //Replace this with your own correct Gmail Address
    
            var _to = emailRecipients;
             
    
            var mail = new System.Net.Mail.MailMessage();
            mail.To.Add(_to);
            mail.From = new System.Net.Mail.MailAddress(@from, _emailDisplayName, System.Text.Encoding.UTF8);           
    
            mail.Subject = emailSubject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = emailContent;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
    
    
            var client = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential(@from, GmailPsw),
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
    
            
                client.Send(mail);
          
        }
