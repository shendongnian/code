    public override void DisplayRecognitionError(string[] tokenNames,
                                        RecognitionException e) {
        string hdr = GetErrorHeader(e);
        string msg = GetErrorMessage(e, tokenNames);
        // Now do something with hdr and msg...
		System.Console.WriteLine("Header:  " + hdr);
		System.Console.WriteLine("Message: " + msg);
		throw new System.Exception("Syntax Error: " + hdr + " " + msg);
    }
