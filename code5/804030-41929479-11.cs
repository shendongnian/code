    IMFMediaSession pI;
	MFCreateMediaSession(null, out pI);  // get magical RCW
	var rcw = (session)pI;   // we happen to know what it really is
	pI.ClearTopologies();    // you can call IMFMediaSession members...
	((IMFAsyncCallback)pI).Invoke(null);  // and also IMFAsyncCallback.
	rcw.Invoke(null);        // same thing, via the backing object
