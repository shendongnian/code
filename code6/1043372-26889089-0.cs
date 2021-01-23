    // N.B: I don't know where you get handle from,
    //      I'll just adapt the code you've posted for simplicity
	public WhateverTypeStatusIs GetState()
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
           
        return status;
	}
    public static void Main()
    {
        while (true)
        {
            var status = GetState();
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
