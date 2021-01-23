    private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
    public void WriteToFile(string text, string path) 
    {
    	_readWriteLock.EnterWriteLock();
    	using (StreamWriter sw = new StreamWriter(path, true))
    	{
    		sw.WriteLine(text);
    		sw.Close();
    	}
    	_readWriteLock.ExitWriteLock();
    }
