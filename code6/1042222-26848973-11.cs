	public class MsmqListener
	{
		privatec ManualResetEvent _stopRequested = new ManualResetEvent(false);
		private List<Thread> _listenerThreads;
        private object _locker = new _locker();
		
		//-----------------------------------------------------------------------------------------------------
		
		public MsmqListener
		{
			CreateListenerThreads();
		}
		
		//-----------------------------------------------------------------------------------------------------
		
		public void Start()
		{
		  StartListenerThreads();
		}
		
		//-----------------------------------------------------------------------------------------------------
		
		public void Stop()
		{
			try
			{
				_stopRequested.Set();
				foreach(Thread thread in _listenerThreads)
				{
					thread.Join(); // Wait for all threads to complete gracefully
				}
			}
			catch( Exception ex)
			{...}
		}
		
		//-----------------------------------------------------------------------------------------------------
		
		private void StartListening()
		{
				while( !_stopRequested.WaitOne(0) ) // Blocks the current thread for 0 ms until the current WaitHandle receives a signal
				{
					lock( _locker )
					{
						postReq = GettingAMessage();
					}
				...
		}
		
		//-----------------------------------------------------------------------------------------------------
		
		private void CreateListenerThreads()
		{
			_listenerThreads = new List<Thread>();
			for (int i = 0; i < Constants.ThreadMaxCount; i++)
			{
				listenerThread = new Thread(StartListening);
				listenerThreads.Add(listenerThread);
			}
		}
		
		//-----------------------------------------------------------------------------------------------------
		
		private void StartListenerThreads()
		{
			foreach(var thread in _listenerThreads)
			{
				thread.Start();
			}
		}
	}
