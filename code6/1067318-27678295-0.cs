    public async Task SendMailsAsync()
    {
         DataTable dt = new DataTable();
    	 var mailTasks = dt.Rows.OfType<DataRow>().Select(mail => 
    	 {
    	 	var smtpClient = new SmtpClient();
    		return smtpClient.SendMailAsync(new MailMessage(from, to, subject, body));
    	 }).ToArray();
    	 
    	 await Task.WhenAll(mailTasks);
    }
