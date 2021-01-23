    protected void ProgramImage()
    {
    	this.OnProgrammingStarted(new EventArgs());
    	this.taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    	Task.Run(() => this.ProgramImageAsync()).ContinueWith(
    							t =>
    							{
    								if (t.IsFaulted)
    								{
    									this.TaskExceptionHandlerProgramming(t);
    								}
    								else
    								{
    									this.ProgramImageAsyncDone();
    								}
    							},
    							this.taskScheduler);
    }
    
    
    public void ReadVersion()
    {
    	this.OnVersionReadingStarted(new EventArgs());
    	Task.Run(() => ReadVersionAsync()).ContinueWith(
    		t =>
    		{
    			if (t.IsFaulted)
    			{
    				this.TaskExceptionHandlerVersionReading(t);
    			}
    			else
    			{
    				this.ReadVersionAsyncDone(t.Result);
    			}
    		},
    				this.taskScheduler);
    }
		
