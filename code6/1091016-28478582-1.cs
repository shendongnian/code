    /// <summary>
	/// Sets a busy handler to sleep the specified amount of time when a table is locked.
	/// The handler will sleep multiple times until a total time of <see cref="BusyTimeout"/> has accumulated.
	/// </summary>
	public TimeSpan BusyTimeout 
    {
		get { return _busyTimeout; }
		set {
			   _busyTimeout = value;
			   if (Handle != NullHandle) 
               {
				   SQLite3.BusyTimeout(Handle, (int)_busyTimeout.TotalMilliseconds);
			   }
            }
    }
