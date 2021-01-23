    public static void SendEmail(string from, string[] to, string[] CC, string[] BCC, string subject, string body, SMTPSettings _smtp = null)
    {
    	Thread email = new Thread(delegate()
    	{
    		SendAsyncEmail(from, to, CC, BCC, subject, body, _smtp);
    	});
    	email.IsBackground = true;
    	email.Start();
    }
    
    private static void SendAsyncEmail(string from, string[] to, string[] CC, string[] BCC, string subject, string body, SMTPSettings _smtp = null)
    {
    	try
    	{
    		MailMessage message = new MailMessage();
    		SmtpClient client = new SmtpClient();		
    		if (_smtp != null)
    		{
    			client.Host = _smtp.SMTPServer;
    			client.Port = Convert.ToInt32(_smtp.SMTPPort);
    			client.EnableSsl = _smtp.SMTPEnableSSL;
    			client.Credentials = new System.Net.NetworkCredential(_smtp.SMTPUserEmail, SMTPPassword);
    		}
    		
    		message.From = new MailAddress(from);
    		message.Subject = subject;
    		message.Body = body;
    		message.IsBodyHtml = true;
    		foreach (string t in to)
    		{
    			message.To.Add(new MailAddress(t));
    		}
    
    		if (CC != null)
    			foreach (string c in CC)
    			{
    				message.CC.Add(new MailAddress(c));
    			}
    
    		if (BCC != null)
    			foreach (string b in BCC)
    			{
    				message.Bcc.Add(new MailAddress(b));
    			}
    		client.Send(message);
    	}
    	catch (Exception ex)
    	{
    		ErrorLogRepository.LogErrorToDatabase(ex, null, null, "");
    	}
    }
