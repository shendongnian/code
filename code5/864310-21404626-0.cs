    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		var asyncSocketListener = new AsynchronousSocketListener();
    		var listenerThread = new Thread(asyncSocketListener.StartListening);
    		listenerThread.Start();
    		Console.WriteLine("Server Started");
    
    		listenerThread.Join();
    		Console.WriteLine("Press any key to exit...");
    		Console.ReadKey();
    	}
    
    	public class Singleton
    	{
    		private static Singleton instance;
    		private bool isEnded;
    
    		private Singleton() { }
    
    		public static Singleton Instance
    		{
    			get
    			{
    				if (instance == null)
    				{
    					instance = new Singleton();
    				}
    				return instance;
    			}
    		}
    
    		public bool IsEnded
    		{
    			get { return isEnded; }
    			set { isEnded = value; }
    		}
    	}
    
    	public class AsynchronousSocketListener
    	{
    		// State object for reading client data asynchronously
    		private class StateObject
    		{
    			// Size of receive buffer.
    			public const int BufferSize = 1024;
    			// Receive buffer.
    			public byte[] Buffer = new byte[BufferSize];
    			// Client  socket.
    			public Socket WorkSocket;
    			// Received data string.
    			public StringBuilder Sb = new StringBuilder();
    		}
    
    		// Thread signal.
    		private static ManualResetEvent allDone = new ManualResetEvent(false);
    
    		public void StartListening()
    		{
    			var localEndPoint = new IPEndPoint(IPAddress.Any, 3000);
    			var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
    			// Bind the socket to the local endpoint and listen for incoming connections.
    			try
    			{
    				listener.Bind(localEndPoint);
    				listener.Listen(100);
    				Console.WriteLine("Listening on {0}...", localEndPoint.ToString());
    
    				while (true)
    				{
    					allDone.Reset();
    
    					if (Singleton.Instance.IsEnded)
    					{
    						Console.WriteLine("Closing listener socket...");
    
    						listener.Close();
    						break;
    					}
    
    					Console.WriteLine("Waiting for a new connection...");
    					listener.BeginAccept(AcceptCallback, state: listener);
    
    					allDone.WaitOne();
    				}
    
    				Console.WriteLine("Server stopped.");
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine(e.ToString());
    			}
    		}
    
    		public static void AcceptCallback(IAsyncResult ar)
    		{
    			Socket clientSocket;
    			try
    			{
    				clientSocket = ((Socket)ar.AsyncState).EndAccept(ar);
    			}
    			catch (ObjectDisposedException)
    			{
    				Console.WriteLine("	Listening socket has been closed.");
    				allDone.Set();
    				return;
    			}
    
    			Console.WriteLine("	Connection accepted {0}", clientSocket.RemoteEndPoint.ToString());
    
    			var stateObject = new StateObject { WorkSocket = clientSocket };
    			clientSocket.BeginReceive(stateObject.Buffer, 0, StateObject.BufferSize, 0, ReadCallback, stateObject);
    
    			// Signal the main thread to continue.
    			Console.WriteLine("	Signal the main thread to accept a new connection");
    			allDone.Set();
    		}
    
    		public static void ReadCallback(IAsyncResult ar)
    		{
    			string content;
    
    			// Retrieve the state object and the handler socket
    			// from the asynchronous state object.
    			var stateObject = (StateObject)ar.AsyncState;
    			Socket clientSocket = stateObject.WorkSocket;
    
    			// Read data from the client socket. 
    			int bytesRead = clientSocket.EndReceive(ar);
    
    			if (bytesRead > 0)
    			{
    				// There  might be more data, so store the data received so far.
    				stateObject.Sb.Append(Encoding.ASCII.GetString(stateObject.Buffer, 0, bytesRead));
    
    				// Check for end-of-file tag. If it is not there, read 
    				// more data.
    				content = stateObject.Sb.ToString();
    				if (content.IndexOf("<EOF>") > -1)
    				{
    					// All the data has been read from the 
    					// client. Display it on the console.
    					Console.WriteLine("		Read {0} bytes from socket. \n		Data : {1}", content.Length, content);
    					if (content.Equals("end<EOF>"))
    					{
    						Console.WriteLine("		!!!Should stop the server");
    						Singleton.Instance.IsEnded = true;
    						allDone.Set();
    					}
    
    					// Echo the data back to the client.
    					byte[] byteData = Encoding.ASCII.GetBytes(content);
    					clientSocket.BeginSend(byteData, 0, byteData.Length, 0, WriteCallback, clientSocket);
    				}
    				else
    				{
    					// Not all data received. Get more.
    					clientSocket.BeginReceive(stateObject.Buffer, 0, StateObject.BufferSize, 0, ReadCallback, stateObject);
    				}
    			}
    		}
    
    		private static void WriteCallback(IAsyncResult ar)
    		{
    			try
    			{
    				// Retrieve the socket from the state object.
    				var clientSocket = (Socket)ar.AsyncState;
    
    				// Complete sending the data to the remote device.
    				int bytesSent = clientSocket.EndSend(ar);
    				Console.WriteLine("			Sent {0} bytes to client.", bytesSent);
    				Console.WriteLine("			Disconnecting the client...");
    
    				clientSocket.Shutdown(SocketShutdown.Both);
    				clientSocket.Close();
    
    				Console.WriteLine("			Client disconnected.");
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine(e.ToString());
    			}
    		}
    	}
    }
