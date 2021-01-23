    public void ModfityJobs(EquipBooking equipBooking)
    		{
    			try
    			{
    				this.IsDataLoaded = true;
    				_context.BeginSaveChanges(ModfityJobsAsynchCallBack, equipBooking);
    			}
    			catch (Exception ex)
    			{
    			}
    		}
    
    		private void ModfityJobsAsynchCallBack(IAsyncResult synchresult)
    		{
    			try
    			{
    				dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
    					{
    						_context.EndSaveChanges(synchresult);
    					});
    			}
    			catch (Exception)
    			{
    				
    				throw;
    			}
    		}
