	private async Task configSendGridasync(IdentityMessage message)
	{
		var smtp = new SmtpClient(Properties.Resources.SendGridURL,587);
		var creds = new NetworkCredential(Properties.Resources.SendGridUser, Properties.Resources.SendGridPassword);
		smtp.UseDefaultCredentials = false;
		smtp.Credentials = creds;
		smtp.EnableSsl = false;
		var to = new MailAddress(message.Destination);
		var from = new MailAddress("info@ycc.com", "Your Contractor Connection");
		var msg = new MailMessage();
		msg.To.Add(to);
		msg.From = from;
		msg.IsBodyHtml = true;
		msg.Subject = message.Subject;
		msg.Body = message.Body;
		await smtp.SendMailAsync(msg);
	}
