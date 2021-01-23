    public virtual void Flush(bool flushToDisk)
    {
    	if (this._handle.IsClosed)
    	{
    		__Error.FileNotOpen();
    	}
    	this.FlushInternalBuffer();
    	if (flushToDisk && this.CanWrite)
    	{
    		this.FlushOSBuffer();
    	}
    }
