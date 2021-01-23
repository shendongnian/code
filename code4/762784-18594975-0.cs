    private void ShowException(Exception ex)
	{
		string title ;
		
		if(ex is TimeoutException)
		{
			title = "Timeout expired" ;
		}
		else if(ex is FaultException)
		{
			title = "A service exception occured" ;
		}
		else if(ex is CommunicationException)
		{
			title = "Communication problem" ;
		}
		else
		{
			title = "An exception occured" ;
		}
        MessageBox.Show(ex.Message, title,MessageBoxButtons.OK, MesssageBoxIcon.Error);
	}
