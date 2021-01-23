    // Process the client connection.
    public static void DoAcceptTcpClientCallback(IAsyncResult ar)
    {
        // Get the listener that handles the client request.
        TcpListener listener = (TcpListener)ar.AsyncState;
		// Wait a while
		Thread.Sleep(10 * 1000);		
		
        // End the operation and display the received data on 
        // the console.
        TcpClient client = listener.EndAcceptTcpClient(ar);
		
		// ...
	}
