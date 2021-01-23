    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Threading.Tasks;
    // ...
    public static async Task SendEmailViaSendGrid(string to, string from, string subject, string body)
    {
		// Generated from https://app.sendgrid.com/settings/api_keys
		// TODO: Store this somewhere secure -- not in version control.
		string apiKey = "YOUR_PRIVATE_SENDGRID_API_KEY_GOES_HERE";
		
		dynamic sendGridClient = new SendGridAPIClient(apiKey);
		
		Email fromEmail = new Email(from);
		Email toEmail = new Email(to);
		Content content = new Content("text/plain", body);
		Mail mail = new Mail(fromEmail, subject, toEmail, content);
		
		dynamic response = await sendGridClient.client.mail.send.post(requestBody: mail.Get());
    }
