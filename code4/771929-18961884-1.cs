	void Main()
	{
		//Trigger the method PrintIncomingMessage when a packet of type 'Message' is received
		//We expect the incoming object to be a string which we state explicitly by using <string>
		NetworkComms.AppendGlobalIncomingPacketHandler<PayloadFile>("Payload", PrintIncomingMessage);
		//Start listening for incoming connections
		TCPConnection.StartListening(true);
		
		//Print out the IPs and ports we are now listening on
		Console.WriteLine("Server listening for TCP connection on:");
		foreach (System.Net.IPEndPoint localEndPoint in TCPConnection.ExistingLocalListenEndPoints()) 
			Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
		
		//Let the user close the server
		Console.WriteLine("\nPress any key to close server.");
		Console.ReadLine();
		
		//We have used NetworkComms so we should ensure that we correctly call shutdown
		NetworkComms.Shutdown();
	
	}
	
	
			/// <summary>
			/// Writes the provided message to the console window
			/// </summary>
			/// <param name="header">The packetheader associated with the incoming message</param>
			/// <param name="connection">The connection used by the incoming message</param>
			/// <param name="message">The message to be printed to the console</param>
			private static void PrintIncomingMessage(PacketHeader header, Connection connection, PayloadFile message)
			{
				connection.SendObject("Ack", "Ok");
				Console.WriteLine("\nA message was recieved from " + connection.ToString() + " which said '" + message + "'.");
			}
	
	
	// Define other methods and classes here
	
		[ProtoContract]
		public class PayloadFile
		{
			[ProtoMember(1)]
			public string FileName { get; set; }
			
			[ProtoMember(2)]
			public string FileLocation { get; set; }
			
			[ProtoMember(3)]
			public byte[] FileContent { get; set; }
		
			public PayloadFile()
			{
			}
		
			public override string ToString()
			{
				var sb = new StringBuilder();
				sb.AppendLine(string.Format("FilaName: {0}", FileName));
				sb.AppendLine(string.Format("FileLocation: {0}", FileLocation));
				sb.AppendLine(string.Format("FileContent: {0}", System.Text.Encoding.UTF8.GetString(FileContent)));
				return sb.ToString();
			}
			
		}
		
