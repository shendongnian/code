    public static void SendEmail(string address, string subject, 
        string message, string email, string username, string password, 
        string smtp, int port)
    {
        var loginInfo = new NetworkCredential(username, password);
        var msg = new MailMessage();
        var smtpClient = new SmtpClient(smtp, port);
        msg.From = new MailAddress(email);
        msg.To.Add(new MailAddress(address));
        msg.Subject = subject;
        msg.Body = message;
        msg.IsBodyHtml = true;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = loginInfo;
        smtpClient.Send(msg);
    }
