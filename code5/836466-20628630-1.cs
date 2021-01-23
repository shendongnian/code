    StringBuilder emailMessage = new StringBuilder();  
    emailMessage.Append("Email body here");  
  
    MailMessage email = new MailMessage();
     email.To.Add(new MailAddress("ReceiverEmailAddress"));  
     email.Subject = "Mail Subject";
            email.From = new MailAddress("sender@gmail.com");
            email.Body = emailMessage.ToString();
            email.IsBodyHtml = true;
            //Send Email;
            SmtpClient client = new SmtpClient();
            client.Send(email);  
