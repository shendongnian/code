    string _sender = "";
            string _password = "";
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(_sender, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;
            MailMessage message = new MailMessage(_sender, "recipient of email");
            message.Subject = "";
            message.Body = "";
            client.Send(message);
