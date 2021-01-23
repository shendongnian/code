    using (var client = new SmtpClient("smtp.gmail.com", 587))
    {
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("MyGmailAddress", "Your Gmail Password");
        string body = string.Format(
            "First Name: {0}, Last Name: {1}, Email: {2}, Comment: {3}",
            c.FirstName,
            c.LastName,
            c.Email,
            c.Comment
        );
        var message = new MailMessage(
            "sender@gmail.com", 
            "MyGmailAddress@gmail.com", 
            "Contact Us", 
            "mail body"
        );
        message.IsBodyHtml = false;
        client.Send(message);
    }
