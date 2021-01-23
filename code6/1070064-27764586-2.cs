	var webTask = Task.Run(() =>
	{
		try 
		{ 
			wcf.UploadMotionDynamicRaw(bytes);  //my web service
		}
		catch (Exception ex)
		{
			//deal with error
		}
	}).ContinueWith(t => taskCounter++);
