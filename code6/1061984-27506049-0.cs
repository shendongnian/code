    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			byte[] bytes = new byte[1024];
    			Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
    			try
    			{
    				socket1.Connect(IPAddress.Parse("127.0.0.1"), 8080);
    				if (socket1.Connected)
    				{
    					Console.WriteLine("Connected");
    					// Encode the data string into a byte array.
    					byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");
    					// Send the data through the socket.
    					int bytesSent = socket1.Send(msg);
    					// Receive the response from the remote device.
    					int bytesRec = socket1.Receive(bytes);
    					Console.WriteLine("Echoed test = {0}",
    						Encoding.ASCII.GetString(bytes, 0, bytesRec));
    					// Release the socket.
    					socket1.Shutdown(SocketShutdown.Both);
    					socket1.Close();
    				}
    				else
    				{
    					Console.WriteLine("not connected");
    				}
    				Console.ReadLine();
    			}
    			catch (Exception e)
    			{
    				
    			}
    		}
    	}
    }
