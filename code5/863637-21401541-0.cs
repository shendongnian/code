    while (true)
    	{
    		try
    		{
    			FileInfo[] files = dir.GetFiles(m_fileTypes);
    			Partitioner<FileInfo> partitioner = Partitioner.Create(files, true);
    			Parallel.ForEach(partitioner, f => 
    			{
    				try
    				{
    					XmlMsg msg = factory.getMessage(messageType);
    					try
    					{
    						msg.loadFile(f.FullName);
    						MsgQueue.Enqueue(new Tuple<XmlMsg, FileInfo>(msg, f));
    					}
    					catch (Exception e)
    					{
    						handleMessageFailed(f, e.ToString());
    					}
    				}
    			});
    			//Added check to wait for queue to deplete before 
                //re-scanning the directory
    			while (MsgQueue.Count > 0)
    			{
    				System.Threading.Thread.Sleep(5000);
    			}
    		}
    	}
