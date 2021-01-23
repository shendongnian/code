    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    namespace ConsoleApplication2
    {
    	class Program
    	{
    		public static string data = null;
    		static void Main(string[] args)
    		{
    			byte[] bytes = new Byte[1024];
    			Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
    			System.Net.IPEndPoint ipEnd = new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 8080);
    			
    			// Bind the socket to the local endpoint and 
    			// listen for incoming connections.
    			try
    			{
    				socket1.Bind(ipEnd);
    				socket1.Listen(10);
    				// Start listening for connections.
    				while (true)
    				{
    					Console.WriteLine("Waiting for a connection...");
    					// Program is suspended while waiting for an incoming connection.
    					Socket handler = socket1.Accept();
    					data = null;
    					// An incoming connection needs to be processed.
    					while (true)
    					{
    						bytes = new byte[1024];
    						int bytesRec = handler.Receive(bytes);
    						data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
    						if (data.IndexOf("<EOF>") > -1)
    						{
    							break;
    						}
    					}
    					// Show the data on the console.
    					Console.WriteLine("Text received : {0}", data);
    					// Echo the data back to the client.
    					byte[] msg = Encoding.ASCII.GetBytes(data);
    					handler.Send(msg);
    					handler.Shutdown(SocketShutdown.Both);
    					handler.Close();
    				}
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine(e.ToString());
    			}
    			Console.ReadLine();
    		}
    	}
    }
