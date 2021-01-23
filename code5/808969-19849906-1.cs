    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		public static async Task Foo(int num)
    		{
    			Console.WriteLine("Thread {0} - Start {1}", Thread.CurrentThread.ManagedThreadId, num);
    
    			await Task.Delay(1000);
    
    			Console.WriteLine("Thread {0} - End {1}", Thread.CurrentThread.ManagedThreadId, num);
    		}
    
    		public static List<Task> TaskList = new List<Task>();
    
    		public static void Main(string[] args)
    		{
    			for (int i = 0; i < 3; i++)
    			{
    				int idx = i;
    				TaskList.Add(Foo(idx));
    			}
    
    			Task.WaitAll(TaskList.ToArray());
    			Console.WriteLine("Press Enter to exit...");
    			Console.ReadLine();
    		}
    	}
    }
