	public class FeatureView
	{	
		// if you still need this property
		public async void HandleFeatureCompleted(FeatureManager fm) 
		{
			try
			{
				await fm.FeatureCompleted.Task;
			}
			catch(Exception e)
			{
				// handle exception
			}
		}
	}
