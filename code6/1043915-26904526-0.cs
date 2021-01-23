        public static void SendMail(string addressTo, string addressFrom, string mailSubject, string mailBody)
        {
            NetworkCredential myCredential = new NetworkCredential(_userName, _passWord);
            SmtpClient client = new SmtpClient();
            client.Host = "99.99.127.233";
            client.Port = 417;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = myCredential;
            client.EnableSsl = true;
            MailAddress from = new MailAddress(addressFrom);
            MailAddress to = new MailAddress(addressTo);
            MailMessage message = new MailMessage(from, to);
            message.Body = mailBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = mailSubject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.Send(message);
        }
