	private static Object tick_time_lock = new Object();
	private static UInt64 _currentTickTime;
	public static UInt64 CurrentTickTime 
	{
		get
		{
            lock (tick_time_lock)
			{
	   	        return _currentTickTime;
            }
		}
		set
		{
			lock (tick_time_lock)
			{
				_currentTickTime = value;
			}
		}
	}
