	public interface IAsyncData
	{
		Task<int> AsyncData { get; }
	}
	// sync version
	class SyncClass : IAsyncData
	{
		readonly Task<int> _data = Task.FromResult(1);
		public Task<int> AsyncData
		{
			get { return _data; }
		}
	}
	// async versions
	class AsyncClass : IAsyncData
	{
		readonly Task<int> _data = GetDataAsync();
		public Task<int> AsyncData
		{
			get { return _data; }
		}
		private static async Task<int> GetDataAsync()
		{
			await Task.Delay(1000);
			return 1;
		}
	}
