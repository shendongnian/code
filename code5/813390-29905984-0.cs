     public class SmtpClientWrapper : ISmtpClient
        {
            public SmtpClient SmtpClient { get; set; }
            public SmtpClientWrapper(string host, int port)
            {
                SmtpClient = new SmtpClient(host, port);
            }
            public void Send(MailMessage mailMessage)
            {
                SmtpClient.Send(mailMessage);
            }
        }
