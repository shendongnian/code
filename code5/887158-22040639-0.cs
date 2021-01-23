    using System;
    
    namespace ConsoleApplication2
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			var myCreatingEventHandler = new EventHandler((sender, eventArgs) => Console.WriteLine("Creating"));
    			var myCreatingEventHandler2 = new EventHandler((sender, eventArgs) => Console.WriteLine("Creating2"));
    			var myDisposingEventHandler = new EventHandler((sender, eventArgs) => Console.WriteLine("Disposing"));
    			var myDisposingEventHandler2 = new EventHandler((sender, eventArgs) => Console.WriteLine("Disposing2"));
    
    			MyClass.Creating += myCreatingEventHandler;
    			MyClass.Disposing += myDisposingEventHandler;
    			using (var test = new MyClass())
    			{
    				// Prints "Creating" and "Disposing".
    			}
    
    			Console.WriteLine();
    
    			MyClass.Creating += myCreatingEventHandler2;
    			MyClass.Disposing += myDisposingEventHandler2;
    			using (var test = new MyClass())
    			{
    				// Prints "Creating", "Creating2", "Disposing" and "Disposing2".
    			}
    
    			Console.WriteLine();
    
    			MyClass.Creating -= myCreatingEventHandler;
    			MyClass.Disposing -= myDisposingEventHandler;
    			using (var test = new MyClass()) {
    				// Prints "Creating2" and "Disposing2".
    			}
    
    			Console.WriteLine();
    
    			MyClass.Creating -= myCreatingEventHandler2;
    			MyClass.Disposing -= myDisposingEventHandler2;
    			using (var test = new MyClass())
    			{
    				// Prints nothing (removed subscriptions to avoid "memory leak".
    			}
    
    			// You may choose call such a method to ensure that ALL handlers are removed from the invocation list.
    			MyClass.RemoveSubscriptions();
    
    			Console.ReadKey();
    		}
    	}
    
    	internal class MyClass : IDisposable
    	{
    		public static event EventHandler Creating;
    
    		private static void OnCreating()
    		{
    			EventHandler handler = Creating;
    			if (handler != null) handler(null, EventArgs.Empty);
    		}
    
    		public static event EventHandler Disposing;
    
    		private static void OnDisposing()
    		{
    			EventHandler handler = Disposing;
    			if (handler != null) handler(null, EventArgs.Empty);
    		}
    
    		public MyClass()
    		{
    			OnCreating();
    		}
    
    		public void Dispose()
    		{
    			OnDisposing();
    		}
    
    		public static void RemoveSubscriptions()
    		{
    			// Setting the events to null can only be done from within the class. From the outside only += and -= are allowed.
    			Creating = null;
    			Disposing = null;
    		}
    	}
    }
