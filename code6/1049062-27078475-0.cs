    public bool SendViaThread(System.Net.Mail.MailMessage message) {
    	bool retVal = false;
    	try {
    		System.Threading.ThreadPool.QueueUserWorkItem(SendAsync, message);
    		retVal = true;
    	} catch (Exception ex) {
    		throw;
    	}
    	return retVal;
    }
    
    
    private void SendAsync(object stateObject) {
    	System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
    	System.Net.Mail.MmailMessage message = (MmailMessage)stateObject;
        ...
        ...
    }
