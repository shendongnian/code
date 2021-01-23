    using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT)) 
	{
		System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("fromfield@example.com",
                                              "tofield@example.com",
                                              "subject",
                                              "<i><strong>body</strong></i>");
		message.IsBodyHtml = true;
		client.Send(message);
	}
