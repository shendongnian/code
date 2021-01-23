	public interface IAsyncInitialize
	{
		Task InitAsync();
		int Data { get; }
	}
	// sync version
	class SyncClass : IAsyncInitialize
	{
		readonly int _data = 1;
		public Task InitAsync()
		{
			return Task.FromResult(true);
		}
		public int Data { get { return _data; } }
	}
	// async version
	class AsyncClass: IAsyncInitialize
	{
		int? _data;
		public async Task InitAsync()
		{
			await Task.Delay(1000);
			_data = 1;
		}
		public int Data
		{
			get 
			{
				if (!_data.HasValue)
					throw new ApplicationException("Data uninitalized.");
				return _data.Value; 
			}
		}
	}
