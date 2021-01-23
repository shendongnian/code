        public async Task SendAsync(IdentityMessage message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                    using (var mailMessage = new MailMessage("your@email.com", message.Destination, message.Subject, message.Body))
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                }
            }
        }
