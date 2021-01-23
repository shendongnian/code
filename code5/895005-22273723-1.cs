    Task.Factory.StartNew(() => {
             SendMail("Hello world", "email@yahoo.com", "TEST");
    });
    public static bool SendMail(string subject, string to, string body)
        {
            string fromMailAddress = ConfigurationManager.AppSettings["MailAddress"];
            string fromMailPassword = ConfigurationManager.AppSettings["MailPassword"];
            string fromMailName = ConfigurationManager.AppSettings["MailName"];
            var networkConfig = new NetworkCredential(fromMailAddress, fromMailPassword);
            var mailServer = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["SmtpHost"],
                UseDefaultCredentials = false,
                Credentials = networkConfig
            };
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SmtpPort"]))
                mailServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            var message = new MailMessage()
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
            };
            //message send config
            message.To.Add(new MailAddress(to));
            message.From = new MailAddress(fromMailAddress, fromMailName);
            message.Body = body;
            try
            {
                mailServer.SendAsync(message, null);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
