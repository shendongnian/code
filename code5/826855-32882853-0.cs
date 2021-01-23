    public void Dispose()
    {
    	// Do your dispose stuff here
    #if DEBUG
    	GC.SuppressFinalize(this);
    }
    ~MyClass()
    {	throw new ObjectNotDisposedException(); // This class is not intended to be used without Dispose.
    #endif
    }
