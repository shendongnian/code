    private void bwAsync_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker bwAsync = sender as BackgroundWorker;
    	if (asyncWorker.IsBusy)
    	{
    		this.Invoke((MethodInvoker)delegate { lblStatus.Text = "Cancelling..."; });
    
    		asyncWorker.CancelAsync();
    	}
    	else
    	{
    		if(isConnected)
    		{
    			host.Close();
    			isConnected = false;
    		}	
    		BindHost();			
    	}
    }
