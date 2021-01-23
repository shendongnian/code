            int port = 587;
            string host = "smtp.office365.com";
            string username = "smtp.out@mail.com";
            string password = "password";
            string mailFrom = "noreply@mail.com";
            string mailTo = "mailto@mail.com";
            string mailTitle = "Testtitle";
            string mailMessage = "Testmessage";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mr MailFromName", mailFrom));
            message.To.Add(new MailboxAddress("Mrs. MailToName", mailTo));
            message.Subject = mailTitle;
            message.Body = new TextPart("plain") { Text = mailMessage };
            using (var client = new SmtpClient())
            {
                client.Connect(, port, SecureSocketOptions.StartTls);
                client.Authenticate(username, password);
                client.Send(message);
                client.Disconnect(true);
            }
