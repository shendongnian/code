    public static void sendEmail(string fsFrom, string fsTo, string fsSubject, String foBody)
    {
        MailMessage loMailMessage = new MailMessage();
        loMailMessage.From = new MailAddress(fsFrom);
        loMailMessage.To.Add(new MailAddress(fsTo));
        loMailMessage.IsBodyHtml = true;
        loMailMessage.Subject = fsSubject;
        loMailMessage.Body = HttpContext.Current.Server.HtmlDecode(foBody);
        SmtpClient loSmtpClient = new SmtpClient();
        loSmtpClient.Send(loMailMessage);
    }
