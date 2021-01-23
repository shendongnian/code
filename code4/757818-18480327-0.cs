    var client = new SmtpClient()
                             {
                                 Host = "smtp.gmail.com",
                                 Port = 587,
                                 EnableSsl = true,
                             };
            var from = new MailAddress(Email);
            var to = new MailAddress(Email);
            var message = new MailMessage(from, to) { Body = Message, IsBodyHtml = IsBodyHtml };
            message.Body += Environment.NewLine + Footer;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = Subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            var nc = new NetworkCredential("me@gmail.com", "password");
            client.Credentials = nc;
            //send email
            client.Send(message);
