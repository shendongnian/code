    using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT)) 
	{
		MailMessage message = new MailMessage("fromfield@example.com",
                                              "tofield@example.com",
                                              "subject",
                                              "<i><strong>body</strong></i>");
		message.IsBodyHtml = true;
		client.Send(message);
	}
