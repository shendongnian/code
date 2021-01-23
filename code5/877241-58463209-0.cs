      public static bool SendEmail(string attachment)
        {
            try
            {
                string smtp = "smtp.gmail.com";
                int port = 587;
                string from = "Gmail Account";
                string password = "Account Password";
                string DisplayName = "Email Subject";
                bool IsHTML = false;
                bool IsSSLEnable = true;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtp);
                mail.From = new MailAddress(from, DisplayName);
                mail.To.Add("Reciever Email");
                mail.Subject = DisplayName ;
                mail.IsBodyHtml = IsHTML;
                mail.Attachments.Add(new Attachment(attachment));
                mail.Body = "This is auto Generated Report";
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(from, password);
                SmtpServer.EnableSsl = IsSSLEnable;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
