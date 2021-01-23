	mail.Body = "Hello" + HttpUtility.HtmlEncode(email.FirstName) + " you are studying " + HttpUtility.HtmlEncode(email.Program);
	smtpclient.EnableSsl = false;
	smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
	smtpclient.Credentials = new System.Net.NetworkCredential(username, password);
	smtpclient.Send(mail);
