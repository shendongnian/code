        using System.Net;
        public static void SendAlertEmail()
        {
           System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
           message.To.Add("receive@whatever.com");
           message.Subject = "Put Subject";
           message.From = new System.Net.Mail.MailAddress("sender@whatever.com");
           message.Body = "Body Message Here";
           System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
           smtp.Host = "put host settings here";
           smtp.Port = 25;
           smtp.EnableSsl = false;
           smtp.Send(message);
        }
