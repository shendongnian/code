        static void SendMail(string sSubject, string sBody)
        {
            const string senderID = "ImTheSender@gmail.com"; // use sender's email id here..
            const string toAddress = "ImTheRecip@gmail.com";
            const string senderPassword = "passwords are fun"; // sender password here...
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here...
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, toAddress, sSubject, sBody);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                LogThis("Error sending mail:" + ex.Message);
                Console.ResetColor();
            }
        }
