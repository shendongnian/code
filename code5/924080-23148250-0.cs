    var smtp = new System.Net.Mail.SmtpClient();
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(sFromEmail);
        string sFrom = mail.From.ToString();
					
        mail.Subject = sSubject;
        mail.Body = sBody;
        mail.IsBodyHtml = true;
                  
        Attachment sMailAttachment;
        sMailAttachment = new Attachment("Your file file");
        mail.Attachments.Add(sMailAttachment);
                   
        smtp.Host = "SMTPP HOST"
        smtp.Port = "PORT" 
        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        smtp.Credentials = new NetworkCredential(sSMTPUserName, sSMTPPassword);
                    
        smtp.Timeout = 30000;
                    
        smtp.Send(mail);  
      }
