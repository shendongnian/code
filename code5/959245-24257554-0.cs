    ExchangeService service = new ExchangeService();  
    service.AutodiscoverUrl("youremailaddress@yourdomain.com");  
    EmailMessage message = new EmailMessage(service);  
    message.Subject = subjectTextbox.Text;  
    message.Body = bodyTextbox.Text;  
    message.ToRecipients.Add(recipientTextbox.Text);  
    message.Save();  
    message.SendAndSaveCopy();
