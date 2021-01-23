        static void SendMail()
        {
            var fromAddress = new MailAddress("fromMail", "App name");
            var toAddress = new MailAddress("tomail","app");
            const string fromPassword = "passwrd";
            const string subject = "test";
            const string body = "Hey now!!";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000,
            };
            using (var message = new MailMessage(fromAddress, toAddress))
            {
                message.Subject = subject;
                message.Body = body;
                smtp.Send(message);
            }
            Console.WriteLine("Sent");
            Console.ReadLine();
        }
