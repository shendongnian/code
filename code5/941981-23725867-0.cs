    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
    
            var mailMessage = new MailMessage
                ("me@example.com", message.Destination, message.Subject, message.Body);
    
            mailMessage.IsBodyHtml = true;
    
            using(var client = new SmtpClient())
            {
                await client.SendMailAsync(mailMessage);
            }
        }
    }
