    IMFMediaSession pI;
	MFError.ThrowExceptionForHR(MFCreateMediaSession(null, out pI));  // get magical RCW
	var rcw = (session)pI;   // we happen to know what it is
	var hr = pI.ClearTopologies();    // you can call IMFMediaSession members...
	hr = ((IMFAsyncCallback)pI).Invoke(null);  // and also IMFAsyncCallback.
	hr = rcw.Invoke(null);   // same thing, via the backing object
