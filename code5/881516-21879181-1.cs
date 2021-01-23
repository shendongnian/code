    public static void SendEmailWebService(string asunto, string body, string to)
    {
        try
        { // takes config from web.config
            MailMessage mm = new MailMessage
            {
                From = new MailAddress(@"no-reply@site.com", @"Notificacion"),
                To = { new MailAddress(to) },
                Subject = asunto,
                IsBodyHtml = true,
                Body = body,
                HeadersEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8,
                BodyEncoding = System.Text.Encoding.UTF8,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("username", "password")
            };
            Smtp.Send(mm);
        }
        catch (Exception ex)
        {
            // Error
        }
    }
