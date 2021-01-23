    namespace PingTest
    {
    	using global::System;
    	using System.Diagnostics;
    	using global::System.Net.NetworkInformation;
    	using System.Text;
    	using System.Threading;
    
    	/// <summary>
    	/// The ping example.
    	/// </summary>
    	public class PingExample
    	{
    		#region Static Fields
    
    		private static bool pingComplete;
    
    		#endregion
    
    		#region Public Methods and Operators
    
    		public static void DisplayReply(PingReply reply)
    		{
    			if (reply == null)
    			{
    				return;
    			}
    
    			Console.WriteLine("ping status: {0}", reply.Status);
    			if (reply.Status == IPStatus.Success)
    			{
    				Console.WriteLine("Address: {0}", reply.Address);
    				Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
    				Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
    				Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
    				Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
    			}
    		}
    
    		public static void Main(string[] args)
    		{
    			if (args.Length == 0)
    			{
    				throw new ArgumentException("Ping needs a host or IP Address.");
    			}
    
    			string who = args[0];
    			var waiter = new AutoResetEvent(false);
    
    			var pingSender = new Ping();
    
    			// When the PingCompleted event is raised, 
    			// the PingCompletedCallback method is called.
    			pingSender.PingCompleted += PingCompletedCallback;
    
    			// Create a buffer of 32 bytes of data to be transmitted. 
    			const string Data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    			byte[] buffer = Encoding.ASCII.GetBytes(Data);
    
    			// Wait 12 seconds for a reply. 
    			const int Timeout = 12000;
    
    			// Set options for transmission: 
    			// The data can go through 64 gateways or routers 
    			// before it is destroyed, and the data packet 
    			// cannot be fragmented.
    			var options = new PingOptions(64, true);
    
    			Console.WriteLine("Time to live: {0}", options.Ttl);
    			Console.WriteLine("Don't fragment: {0}", options.DontFragment);
    
    			// Send the ping asynchronously. 
    			// Use the waiter as the user token. 
    			// When the callback completes, it can wake up this thread.
    			pingComplete = false;
    			var watch = Stopwatch.StartNew();
    			watch.Start();
    			pingSender.SendAsync(who, Timeout, buffer, options, waiter);
    
    			while (!pingComplete && watch.ElapsedMilliseconds <= Timeout)
    			{
    				// Do display stuff for your progress bar here.
    			}
    
    			// Prevent this example application from ending. 
    			// A real application should do something useful 
    			// when possible.
    			waiter.WaitOne();
    			Console.WriteLine("Ping example completed.");
    			Console.ReadLine();
    		}
    
    		#endregion
    
    		#region Methods
    
    		private static void PingCompletedCallback(object sender, PingCompletedEventArgs e)
    		{
    			// If the operation was canceled, display a message to the user. 
    			if (e.Cancelled)
    			{
    				Console.WriteLine("Ping canceled.");
    
    				// Let the main thread resume.  
    				// UserToken is the AutoResetEvent object that the main thread  
    				// is waiting for.
    				((AutoResetEvent)e.UserState).Set();
    			}
    
    			// If an error occurred, display the exception to the user. 
    			if (e.Error != null)
    			{
    				Console.WriteLine("Ping failed:");
    				Console.WriteLine(e.Error.ToString());
    
    				// Let the main thread resume. 
    				((AutoResetEvent)e.UserState).Set();
    			}
    
    			PingReply reply = e.Reply;
    			pingComplete = true;
    
    			DisplayReply(reply);
    
    			// Let the main thread resume.
    			((AutoResetEvent)e.UserState).Set();
    		}
    
    		#endregion
    	}
    }
