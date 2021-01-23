     SmtpClient client = new SmtpClient();  
     MailMessage message = new MailMessage();  
     message.To.Add(to);  
     message.Body = "This is Test message";  
     message.Subject = "hi";`    
      
