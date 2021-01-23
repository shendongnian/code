        public void SendEmails(string from, string to, string subject, string body)
        {
            var msg = new MailMessage(from, to, subject, body)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };
            
            EmailThread.Instace.Messages.Enqueue(msg);
        }
