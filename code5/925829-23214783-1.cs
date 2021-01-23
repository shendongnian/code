    public static void ReadFullyAndSend( Stream input )
    {
       using ( MemoryStream ms = new MemoryStream() )
       {
          input.CopyTo( ms );
          
        	MailMessage message = new MailMessage("from@foo.com", "too@foo.com");
        		Attachment attachment = new Attachment(ms, "my attachment");
        		message.Attachments.Add(attachment);
        		message.Body = "This is an async test.";
    
        		SmtpClient smtp = new SmtpClient("localhost");
        		smtp.Credentials = new NetworkCredential("foo", "bar");
        		smtp.SendAsync(message, null);
       }
    }  
