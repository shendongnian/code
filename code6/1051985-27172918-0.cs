    MailMessage message = new MailMessage("queensqsis@gmail.com", "queensqsis@gmail.com");// to & from
    
    //For each item in the list, add it to the list of "To" recipients
    emailresult.ForEach(r => message.To.Add(r)) ;
    //OR IF THE ADDRESS IS A PROPERTY OF THE ITEM
    emailresult.ForEach(r => message.To.Add(r.MyEmailAddressProperty)) ;
    
    message.Subject = "Test";
    message.Body = "test ";
    
    
    SmtpClient Client = new SmtpClient();
    Client.Send(message);
