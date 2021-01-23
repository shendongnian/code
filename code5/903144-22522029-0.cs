	class Updater : IDisposable
	{
		private readonly Mutex _mutex;
		public Updater(string mutexName)
		{
			bool createdNew;
			_mutex = new Mutex(false, mutexName, out createdNew);
			if (!_mutex.WaitOne(TimeSpan.FromSeconds(5)) throw new Exception("I could not acquire mutex");
		}
		
		public void Update()
		{
			// Perform the update
		}
		
		public void Dispose()
		{
			_mutex.ReleaseMutex();
			_mutex.Close();
		}
	}
	using (var updater = new Updater("NinjaMutexAwesomePants"))
	{
		updater.Update();
	}
