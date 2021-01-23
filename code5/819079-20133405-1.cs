        public void Send(MailAddress toAddress, string subject, string body, bool priority)
        {
            Task.Factory.StartNew(() => SendEmail(toAddress, subject, body, priority), TaskCreationOptions.LongRunning);
        }
        private void SendEmail(MailAddress toAddress, string subject, string body, bool priority)
        {
            MailAddress fromAddress = new MailAddress(WebConfigurationManager.AppSettings["SmtpFromAddress"]);
            string serverName = WebConfigurationManager.AppSettings["SmtpServerName"];
            int port = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPort"]);
            string userName = WebConfigurationManager.AppSettings["SmtpUserName"];
            string password = WebConfigurationManager.AppSettings["SmtpPassword"];
            var message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.HeadersEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            if (priority) message.Priority = MailPriority.High;
            Thread.Sleep(1000);
            SmtpClient client = new SmtpClient(serverName, port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["SmtpSsl"]);
                client.UseDefaultCredentials = false;
                NetworkCredential smtpUserInfo = new NetworkCredential(userName, password);
                client.Credentials = smtpUserInfo;
                client.Send(message);
                client.Dispose();
                message.Dispose();
        }
