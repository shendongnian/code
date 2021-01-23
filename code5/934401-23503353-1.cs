    protected void button1_Click(object sender, EventArgs e)
    {
    	var bg = new BackgroundWorker();
    	bg.DoWork += delegate
    	{
    		try
    		{
    			Thread.Sleep(10000); //do nothing for 10 seconds
    		}
    		catch (Exception ex)
    		{
    			//no excpeiton is thrown
    		}
    
    	};
    	bg.RunWorkerAsync();
    }
