	class NonExpiringLazyLoadingCache<T>
	{
		private readonly Func<Task<T>> _factory;
		private Task<T> _retrievalTask;
		private readonly object _lockObject = new object();
		public NonExpiringLazyLoadingCache(Func<Task<T>> factory)
		{
			this._factory = factory;
		}
		public async Task<T> GetValue()
		{
			lock (this._lockObject)
				if (this._retrievalTask == null)
					this._retrievalTask = this._factory();
			await this._retrievalTask;
			return this._retrievalTask.Result;
		}
	}
