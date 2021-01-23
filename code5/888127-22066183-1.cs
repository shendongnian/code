    private bool bStopTimer = true;
    private void StartTimer()
    {
    	System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadTimer));
    	thread.IsBackground = true;
    	thread.Start();
    }
    
    
    private void ThreadTimer()
    {
    	while (bStopTimer)
    	{
    		System.Threading.Thread.Sleep(1000); //interval in millisecond
    		lock(lblLabel.Text)
    		{
    			lblLable.Text = System.DateTime.Now.ToString("HH:mm:ss");
    		}
    	}
    }
