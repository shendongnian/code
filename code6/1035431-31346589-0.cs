	// CA2213 detects an issue
	class OwnsTheField : IDisposable
	{
	    private MemoryStream f = new MemoryStream();
	    public void Dispose() {}
	}
