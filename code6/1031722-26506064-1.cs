        public void Send(string address, string subject, string body, string from, bool isHtml)
        {
            using (var message = new MailMessage(from, address))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;
                using (var client = new SmtpClient("EX2010.yourdomain.com", 25 /* default port */))
                {
                    client.EnableSsl = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("user@yourdomain.com", "password");
                    client.Send(message);
                }
            }
        }
