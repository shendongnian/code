    namespace YourProject.Services
    {
        public class EmailService : IIdentityMessageService
        {
    
            public async Task SendAsync(IdentityMessage message)
            {
                await configSendGridasync(message);
            }
    
            // Use NuGet to install SendGrid (Basic C# client lib) 
            private async Task configSendGridasync(IdentityMessage message)
            {
                var myMessage = new SendGridMessage();
                myMessage.AddTo(message.Destination);
                myMessage.From = new System.Net.Mail.MailAddress("no-reply@your-domain.com", "Customer Service");
                myMessage.Subject = message.Subject;
                myMessage.Text = message.Body;
                myMessage.Html = message.Body;
    
                var credentials = new NetworkCredential(
                           ConfigurationManager.AppSettings["SendGridUsername"],
                           ConfigurationManager.AppSettings["SendGridPassword"]
                           );
    
                // Create a Web transport for sending email.
                var transportWeb = new Web(credentials);
    
                // Send the email.
                if (transportWeb != null)
                {
                    await transportWeb.DeliverAsync(myMessage);
                }
                else
                {
                    Trace.TraceError("Failed to create Web transport.");
                    await Task.FromResult(0);
                }
            }
        }
    }
