    var outputMsg = new StringBuilder();    
    outputMsg.AppendLine("<b>The date today is : " + DateTime.Now.Date + "</b>"); 
    
    var body = outputMsg.ToString();
    
    MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);
    message.IsBodyHtml = true;
