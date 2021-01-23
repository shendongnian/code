    private static IEnumerable<MyDto> InitializeCache()
	{
		lock (_monitor) // here all threads but one will stop
		{
			var result = _instance.Get(SOME_NAME); // in case this thread is not the first who entered the lock
			if (result == null)
			{
				result = RetrieveSomeHowYourDataFromDbOrService();
				if (result == null)
					return null; // or exception
				_instance.Set(SOME_NAME, result, new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddSeconds(TIMEOUT)), RemovedCallback = CacheClearedCallback}); 
			}
			return (IEnumerable<MyDto>)result;
		}
	}
