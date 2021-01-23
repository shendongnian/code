		public string CallbackURL()
		{
			string vals = "";
			// get all the sent data 
			foreach (String key in Request.QueryString.AllKeys)
				vals += key + ": " + Request.QueryString[key] + Environment.NewLine;
			// send all received data to email or use other logging mechanism
			// make sure you have the host correctly setup in web.config
			SmtpClient smptClient = new SmtpClient();
			MailMessage mailMessage = new MailMessage();
			mailMessage.To.Add("...@...com");
			mailMessage.From = new MailAddress("..@....com");
			mailMessage.Subject = "callback received";
			mailMessage.Body = "Received data: " + Environment.NewLine + vals;
			mailMessage.IsBodyHtml = false;
			smptClient.Send(mailMessage);
			// TODO: process data (save to database?)
			
			// disaplay the data (for degugging purposes only - to be removed)
			return vals.Replace(Environment.NewLine, "<br />");
		}
