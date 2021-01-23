    public void SetPosition(double value)
    {
    	if (_audioFileReader != null)
    	{
    		_audioFileReader.CurrentTime = TimeSpan.FromSeconds(value);
    	}
    }
