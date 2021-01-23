    public string PathToFfmpeg { get; set; }    
    public void ToFlacFormat(string pathToMp4, string pathToFlac)
    {
    	var ffmpeg = new Process
    	{
    		StartInfo = {UseShellExecute = false, RedirectStandardError = true, FileName = PathToFfmpeg}
    	};
    
    	var arguments =
    		String.Format(
    			@"-i ""{0}"" -c:a flac ""{1}""", 
    			pathToMp4, pathToFlac);
    											   
    	ffmpeg.StartInfo.Arguments = arguments;
    
    	try
    	{
    		if (!ffmpeg.Start())
    		{
    			Debug.WriteLine("Error starting");
    			return;
    		}
    		var reader = ffmpeg.StandardError;
    		string line;
    		while ((line = reader.ReadLine()) != null)
    		{
    			Debug.WriteLine(line);
    		}
    	}
    	catch (Exception exception)
    	{
    		Debug.WriteLine(exception.ToString());
    		return;
    	}
    
    	ffmpeg.Close();
    }
     
