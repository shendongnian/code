        public void Send(string address, string subject, string body, string from, bool isHtml)
        {
            using (var message = new MailMessage(from, address))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;
                using (var client = new SmtpClient("some_exchange_host.com", SomeExchangePort))
                {
                    client.EnableSsl = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("login", "password");
                    client.Send(message);
                }
            }
        }
