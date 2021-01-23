    public double GetPositionInSeconds()
    {
    	if (_audioFileReader != null)
    	{
    		return _audioFileReader.CurrentTime.TotalSeconds;
    	}
    	else
    	{
    		return 0;
    	}
    }
