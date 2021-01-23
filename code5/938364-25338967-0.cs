    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSMTPasync(message);
        }
        // send email via smtp service
        private async Task configSMTPasync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            var credentialUserName = "info@ourdoamin.com";
            var sentFrom = "noreply@ourdoamin.com";
            var pwd = "ourpassword";
            // Configure the client:
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.ourdomain.com");
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            // Creatte the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(credentialUserName, pwd);
            client.EnableSsl = false;
            client.Credentials = credentials;
            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            await client.SendMailAsync(mail);
        }
    }
