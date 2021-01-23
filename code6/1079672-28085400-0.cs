    EmailMessage message = new EmailMessage();
     Recipient myrecipient = new Recipient("Gmail", "MyMail@gmail.com");
     message.To.Add(myrecipient);
     //Adding more To address
     message.To.Add(myrecipient2);
     message.To.Add(myrecipient3);
     //Adding more CC address
     message.Cc.Add(myrecipient4);
     message.Cc.Add(myrecipient5);
     //Adding more Bcc address
     message.Bcc.Add(myrecipient6);
     message.Bcc.Add(myrecipient7);
     message.Subject = "test from Windows-Mobile";                          
     message.BodyText = "this is the test from Windows-Mobile";        
     //Adding attachments
     message.Attachments.Add("TextFilePath");
     message.Send("Gmail");                                                
     MessagingApplication.Synchronize("Gmail");                     
     SetForegroundWindow(this.Handle);   
  
