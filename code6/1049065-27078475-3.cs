    public void SendViaThread(System.Net.Mail.MailMessage message) {
    	try {
    		System.Threading.ThreadPool.QueueUserWorkItem(SendViaAsync, message);
    	} catch (Exception ex) {
    		throw;
    	}
    }
    
    private void SendViaAsync(object stateObject) {
    	System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
    	System.Net.Mail.MmailMessage message = (MmailMessage)stateObject;
        ...
		smtp.Credentials = new NetworkCredential("...");
		smtp.Port = 587;
		smtp.Host = "...";
        ...
		smtp.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
        ...
        smtp.Send(message);
    }
