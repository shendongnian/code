    public void WriteHeadersToSharedVariable()
    {
        	//here, setting the headers into the shared variable instanced back on the console program
            HostInterface.Headerstring = GetHeadersFromRequest();
    }
    public string GetHeadersFromRequest()
    {
    	//some code to get the headers from inbound request
      	return "blah blah blah";
    }
