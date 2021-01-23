    public static void CreateMessageWithAttachment(string server)
		{
			MemoryStream file = // Your Memeory stream to send as attachment
			MailMessage message = new MailMessage(
			   "abc@xyz.com",
			   "pqr@xyz.com",
			   "report.",
			   "See the attached pdf.");
			Attachment data = new Attachment( file , "example.pdf", "application/pdf" );
			message.Attachments.Add(data);
			//Send the message.
			SmtpClient client = new SmtpClient(server);
			// Add credentials if the SMTP server requires them.
			client.Credentials = CredentialCache.DefaultNetworkCredentials;
			  client.Send(message);
		  
			}
