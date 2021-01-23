    public void SendMail(string smtpAddress, string from, string to, string body, string subject, bool isHtml, Stream attachmentStream, string fileName)
    {
        SmtpClient smtpClient = new SmtpClient(smtpAddress);
        MailMessage email = new MailMessage();
        email.From = new MailAddress(from);
        email.To.Add(to);    
        email.Body = body;
        email.Subject = subject;
        email.IsBodyHtml = isHtml;
        smtpClient.EnableSsl = true;
        email.Attachments.Add(new Attachment(attachmentStream, fileName));
 
        NetworkCredential myCreds = new NetworkCredential("youremail@gmail.com", "yourpassword", "");
        smtpClient.Credentials = myCreds;
 
        smtpClient.Send(email);
    }
