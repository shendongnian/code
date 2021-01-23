    hubProxy.Invoke("JoinGroup", hubConnection.ConnectionId, "SignalRChatRoom").Wait();
	// Summary:
	//     Executes a method on the server side hub asynchronously.
	//
	// Parameters:
	//   method:
	//     The name of the method.
	//
	//   args:
	//     The arguments
	//
	// Type parameters:
	//   T:
	//     The type of result returned from the hub
	//
	// Returns:
	//     A task that represents when invocation returned.
	Task<T> Invoke<T>(string method, params object[] args);
