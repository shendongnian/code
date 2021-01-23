    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Credentials:
            string sendGridUserName = "HansMuster456";
            string sentFrom = "OwinIdentityTest@TestDomain.ch";
            string sendGridPassword = "xxxxx";
    
            // Configure the client
            var client = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", 587);
    
            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
    
            // Create the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(sendGridUserName, sendGridPassword);
    
            //client.EnableSsl = true;
            client.Credentials = credentials;
    
            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);
    
            mail.Subject = message.Subject;
            mail.Body = message.Body;
    
            // Send:
            return client.SendMailAsync(mail);
        }
    }
