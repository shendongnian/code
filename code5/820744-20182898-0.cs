	void Deploy(string projectPath, string publishProfilePath, ILogger logger)
	{
		lock (deployLock)
		{
			//Implementation
		}
	}
	object deployLock = new object();
