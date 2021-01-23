    public class EmailService
    {
        public static async Task SendMessage(MailMessage message)
        {
            var client = new SmtpClient("127.0.0.1", 25);
            await client.SendMailAsync(message, message);
        }
    }
