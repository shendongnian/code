    private async void DoSomethingAsync()
    {
    	try
    	{
    		DoanloadEmailsCommand.IsEnabled = false;
    
    		await Task.Run(() =>
    		{
    			// Do something here. For example, work with the database, download emails, etc.
    			Emails = DownloadEmails();
    		});
    	}
    	finally
    	{
    		DoanloadEmailsCommand.IsEnabled = true;
    	}
    
    	MessageBox.Show(string.Format("{0} emails have been downloaded.", Emails.Count));
    }
