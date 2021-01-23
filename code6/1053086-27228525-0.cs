	public class FeatureManager
	{
		public TaskCompletionSource<bool> FeatureCompleted { get; private set; }
		
		// if you still need this property
		public bool IsFeatureEnabled 
		{
			get { return FeatureCompleted.Task.IsCompleted; }
		}
		
		public FeatureManager() {}
		public async Task EnableFeature()
		{
			IsFeatureEnableBusy = true;
			try
			{             
				// By its nature, process of enabling this feature is asynchronous. 
				await EnableFeatureImpl(); // can throw exception
				this.FeatureCompleted.TrySetResult(true);
			}
			catch(Exception exc)
			{
				this.FeatureCompleted.TrySetException(exc);
			}
			finally
			{
				IsFeatureEnableBusy = false;
			}
		} 
	}
