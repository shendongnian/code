	MailMessage message = new System.Net.Mail.MailMessage(); 
	string fromEmail = "myaddr@gmail.com";
	string fromPW = "mypw";
	string toEmail = "recipient@receiver.com";
	message.From = new MailAddress(fromEmail);
	message.To.Add(toEmail);
	message.Subject = "Hello";
	message.Body = "Hello Bob ";
	message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
	
	SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
	smtpClient.EnableSsl = true;
	smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
	smtpClient.UseDefaultCredentials = false;
	smtpClient.Credentials = new NetworkCredential(fromEmail, fromPW);
	
	smtpClient.Send(message.From.ToString(), message.To.ToString(), 
				message.Subject, message.Body);   
