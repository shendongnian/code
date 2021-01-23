    public void GetState() 
    { 
		while (true)
		{
			if (handle == null)
			{
				Thread.Sleep(1000);
				continue;
			}
			var status = handle.GetStatus();
			if (status.IsSeeding)
			{
                break;
            }
            Console.WriteLine("State: {0}, Up: {1}, Down: {2}, Process: {3}",
                              status.State.ToString(),
                              status.UploadRate,
                              status.DownloadRate,
                              status.Progress);
			Thread.Sleep(1000);
		}  
	}
