    public void SendAsyncEmail(MailMessage message)
            {
                   
                var client = new SmtpClient("mail.hover.com", 587)
                {
                    Credentials = new NetworkCredential("admin@site.com", "Covert00!"),
                    EnableSsl = false
                };
                client.SendCompleted += (sender, error) =>
                {
                    if (error.Error != null)
                    {
                        // TODO: get this working
                        throw new WarningException("Email Failed to send.");
                    }
                    client.Dispose();
                    message.Dispose();
                };
                ThreadPool.QueueUserWorkItem(o => client.SendAsync(message, Tuple.Create(client, message)));
            }
