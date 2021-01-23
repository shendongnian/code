    // Microsoft.WindowsAzure.Storage.Queue.QueueRequestOptions
    internal void ApplyToStorageCommand<T>(RESTCommand<T> cmd)
    {
    	if (this.LocationMode.HasValue)
    	{
    		cmd.LocationMode = this.LocationMode.Value;
    	}
    	if (this.ServerTimeout.HasValue)
    	{
    		cmd.ServerTimeoutInSeconds = new int?((int)this.ServerTimeout.Value.TotalSeconds);
    	}
    	if (this.OperationExpiryTime.HasValue)
    	{
    		cmd.OperationExpiryTime = this.OperationExpiryTime;
    		return;
    	}
    	if (this.MaximumExecutionTime.HasValue)
    	{
    		cmd.OperationExpiryTime = new DateTime?(DateTime.Now + this.MaximumExecutionTime.Value);
    	}
    }
