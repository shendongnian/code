    public override String ReadToEnd()
    {
    	if (stream == null)
    		__Error.ReaderClosed();
    
    #if FEATURE_ASYNC_IO
    	CheckAsyncTaskInProgress();
    #endif
    
    	// Call ReadBuffer, then pull data out of charBuffer.
    	StringBuilder sb = new StringBuilder(charLen - charPos);
    	do {
    		sb.Append(charBuffer, charPos, charLen - charPos);
    		charPos = charLen;  // Note we consumed these characters
    		ReadBuffer();
    	} while (charLen > 0);
    	return sb.ToString();
    }
