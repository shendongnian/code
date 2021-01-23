     class Program
    	{
    		private static void timer_ElapsedEventHandler(object sender, EventArgs e)
    		{
    			// communicate to external service
    			Console.WriteLine("ElapsedEventHandler fired");
    		}
    
    		static void Main(string[] args)
    		{
    			var timer = new System.Timers.Timer();
    			timer.Interval = 3000;
    			timer.Elapsed += timer_ElapsedEventHandler;
    			timer.Start();
    			Console.WriteLine("Timer started");
    			
    			Console.ReadLine();
    		}
    	}
