	class Server
	{
		private int port;
		private Socket serverSocket;
		private List<StateObject> clientList;
		private const int DEFAULT_PORT = 1338;
		public Server()
		{
			this.port = 1338; //default port
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			clientList = new List<StateObject>();
		}
		public Server(int port)
		{
			this.port = port;
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			clientList = new List<StateObject>();
		}
		public void startListening(int port = DEFAULT_PORT)
		{
			this.port = port;
            //Bind to our port
			serverSocket.Bind(new IPEndPoint(IPAddress.Any, this.port));
            //Listen on the port
			serverSocket.Listen(1);
            //Async Method to wait for a client to connect
			serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
		}
		private void AcceptCallback(IAsyncResult AR)
		{
			try
			{
                //A client has connected so create a stateobject for them
                //This will hold their buffer and socket
				StateObject state = new StateObject();
                //This is where the socket is passed to our state
				state.workSocket = serverSocket.EndAccept(AR);
                //Add this client to our client list
				clientList.Add(state);
                //Async method to receive data from them (Non Blocking)
				state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
                //Immediately go back to waiting for a new client (Non Blocking)
				serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
			}
			catch { }
		}
		private void ReceiveCallback(IAsyncResult AR)
		{
            //A client has sent us data
            //We pass ourselves the state in our previous method
            //Now we can retrieve that StateObject from the callback
			StateObject state = (StateObject)AR.AsyncState;
            //Use this to get the socket so we can retrieve the data from it
			Socket s = state.workSocket;
            //Variable to hang on to the amount of data we received
			int received = 0;
            //Call the socket EndReceive Method
			received = s.EndReceive(AR);
            //If we received no data from the client, they have disconnected
			if (received == 0)
			{
                //Remove them from our clientlist
				clientList.Remove(state);
                //Tell the other clients that they have left
				foreach (StateObject others in clientList)
					others.workSocket.Send(Encoding.ASCII.GetBytes("Client disconnected " + s.LocalEndPoint));
                //We return here - this callback thread is now dead.
				return;
			}
            //If we received data
			if (received > 0) {
                //Append the data to our StringBuilder
				state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, received));
            }
            //Build the string and let's see if it contains a new line character
			string content = state.sb.ToString();
            //If the data has a new line character
			if(content.Contains("\n") && content.Length > 1)
			{
                //Send this data to every other client
				foreach (StateObject others in clientList)
					if (others != state) //Make sure we don't send it back to the sender
						others.workSocket.Send(Encoding.ASCII.GetBytes(content.ToCharArray()));
				state.sb.Clear(); //Clear their StringBuilder so we can retrieve the next message
			}
            //Clear the temporary buffer
			Array.Clear(state.buffer, 0, StateObject.BufferSize);
            //And prepare to receive more data
			s.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
		}
	}
	class StateObject
	{
		public Socket workSocket = null;
		public const int BufferSize = 1024;
		public byte[] buffer = new byte[BufferSize];
		public StringBuilder sb = new StringBuilder();
	}
