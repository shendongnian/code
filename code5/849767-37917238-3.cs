    public double GetLenghtInSeconds()
    {
    	if (_audioFileReader != null)
    	{
    		return _audioFileReader.TotalTime.TotalSeconds;
    	}
    	else
    	{
    		return 0;
    	}
    }
