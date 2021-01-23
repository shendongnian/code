    MailMessage message = new MailMessage("queensqsis@gmail.com", "queensqsis@gmail.com");// to & from
    for(var item in emailresult){
        message.To.Add(item);
    }
    
    message.Subject = "Test";
    message.Body = "test ";
    
    
    SmtpClient Client = new SmtpClient();
    Client.Send(message);
