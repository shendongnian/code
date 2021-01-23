	using (var mail = new MailMessage())
	{
		using (var client = new SmtpClient(MailServer))
		{
			mail.From = new MailAddress(FromAddress);
			foreach (string to in ToAddress)
			{
				mail.To.Add(to);
			}
			mail.Subject = Subject + fileName;
			mail.Body = message.ToString();
			mail.IsBodyHtml = true;
			client.Send(mail); 
		}
	}
