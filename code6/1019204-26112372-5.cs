    smtp1.SendAsync(msg1, "Test Message 1");
    smtp1.SendCompleted += new SendCompletedEventHandler(this.SendCompletedCallback);
    
    
    smtp2.SendAsync(msg2, "Test Message 2");
    smtp2.SendCompleted += new SendCompletedEventHandler(this.SendCompletedCallback);
    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
    	// Get the unique identifier for this asynchronous operation.
    	String token = (string) e.UserState;
    
    	if (token == "Test Message 1")
    	    //This is the First email status
    	else if (token == "Test Message 2")
    	    //This is the second email status
    }
