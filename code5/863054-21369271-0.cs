    MailMessage message = new MailMessage(from, to);
    message.Subject = subject;
    message.Body = body;
    SmtpClient client = new SmtpClient(server);
    client.Credentials = new NetworkCredentials( username, password );
	
    client.Send(message);
