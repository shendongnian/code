    public void SendViaThread(System.Net.Mail.MailMessage message) {
    	try {
    		System.Threading.ThreadPool.QueueUserWorkItem(SendAsync, message);
    	} catch (Exception ex) {
    		throw;
    	}
    }
    
    private void SendAsync(object stateObject) {
    	System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
    	System.Net.Mail.MmailMessage message = (MmailMessage)stateObject;
        ...
        ...
    }
