         public static void sendEmailMessage(StringBuilder stringBuilder, string email_ToAddress, string email_Subject)
		{
			DateTime now = DateTime.Now;
			DateTime yesterday = DateTime.Now.AddDays(-1);
			MailMessage mail = new MailMessage();
			//SomeEmailAccount@yourOrganization.com    must be set by your Sysadmin before using it.
			mail.From = new MailAddress("SomeEmailAccount@yourOrganization.com");
			mail.To.Add(email_ToAddress);
			mail.Subject = $"{email_Subject} . Date #{now.ToShortDateString()}";
			mail.Body = stringBuilder.ToString();
			mail.IsBodyHtml = true;
			NetworkCredential autentificare = new NetworkCredential();
			autentificare.UserName = "SomeEmailAccount@yourOrganization.com"";
			autentificare.Password = "yourPassw0rd";
			SmtpClient smtp = new SmtpClient();
			smtp.Host = "mail.yourOrganization.com";
			smtp.UseDefaultCredentials = true;
			smtp.Credentials = autentificare;
			smtp.Port = 25;
			smtp.EnableSsl = false;
			smtp.Send(mail);
		}
