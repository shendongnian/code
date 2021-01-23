    public class AuthMessageSender : IEmailSender, ISmsSender <br/>
    { <br/>
        public Task SendEmailAsync(string email, string subject, string message) <br/>
        { <br/>
            var mailMessage = new MailMessage(email, email, subject, message); <br/>
            var builder = new ConfigurationBuilder(); <br/>
            var config = builder.Build(); <br/>
            var client = new SmtpClient("smtp.live.com", 587) <br/>
            { <br/>
                Credentials = new NetworkCredential("jon@doe.com", "password"),
                EnableSsl = true <br/>
            };<br/>
            client.Send(email, "ToAddress@gmail.com", subject, message); <br/>
            return Task.FromResult(0); <br/>
        } <br/>
    }
