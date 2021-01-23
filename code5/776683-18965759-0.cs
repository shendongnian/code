    Parallel.ForEach(usersList, (string email) =>
    { 
       if(Regex.IsMatch(Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") 
       {
    
         SmtpClient smtpClient = new SmtpClient();
         MailMessage message = new MailMessage();
         MailAddress AddressFrom = new MailAddress(emailFrom);
         message.From = AddressFrom;
         MailAddress AddressTo = new MailAddress(Email);
         message.To.Add(Email);
         smtpClient.Send(message);
         message.Dispose();
         smtpClient.Dispose();
       }
    });
