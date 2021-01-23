    public class UserIncrementalObservableCollection : BaseIncrementalObservableCollection<User>
    {
		protected override Task<IList<User>> LoadMoreItemsOverrideAsync(CancellationToken c, uint count) 
		{
			// your call to the webservice
		}
		protected override bool HasMoreItemsOverride() 
		{
			// check if there are more
		}
    }
