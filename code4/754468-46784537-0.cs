	var linkedResource = new LinkedResource(@"C:\Image.jpg", MediaTypeNames.Image.Jpeg);
	
	// My mail provider would not accept an email with only an image, adding hello so that the content looks less suspicious.
	var htmlBody = $"hello<img src=\"cid:{linkedResource.ContentId}\"/>";
	var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
	alternateView.LinkedResources.Add(linkedResource);
	var mailMessage = new MailMessage
	{
		From = new MailAddress("youremail@host.com"),
		To = { "recipient@host.com" },
		Subject = "yourSubject",
		AlternateViews = { alternateView }
	};
	
	var smtpClient = new SmtpClient();
	smtpClient.Send(mailMessage);
