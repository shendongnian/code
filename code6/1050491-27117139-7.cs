	static class Extensions
	{
		// Implementation to jQuery-like `then` function in .NET
		// According to: http://blogs.msdn.com/b/pfxteam/archive/2012/08/15/implementing-then-with-await.aspx
		// Further reading: http://blogs.msdn.com/b/pfxteam/archive/2010/11/21/10094564.aspx
		public static async Task Then(this Task task, Func<Task> continuation) 
		{ 
			await task; 
			await continuation(); 
		} 
		public static async Task<TNewResult> Then<TNewResult>( 
			this Task task, Func<Task<TNewResult>> continuation) 
		{ 
			await task; 
			return await continuation(); 
		} 
		public static async Task Then<TResult>( 
			this Task<TResult> task, Func<TResult,Task> continuation) 
		{ 
			await continuation(await task); 
		} 
		public static async Task<TNewResult> Then<TResult, TNewResult>( 
			this Task<TResult> task, Func<TResult, Task<TNewResult>> continuation) 
		{ 
			return await continuation(await task); 
		}
	}
	class MainClass
	{
		public static async Task<String> AsyncMethod1(int delay) {
			await Task.Delay (TimeSpan.FromSeconds(delay));
			return "The method has finished it's execution after waiting for " + delay + " seconds";
		}
		public static Task<String> AsyncMethod2(int delay)
		{
			return Task.Delay (TimeSpan.FromSeconds (delay)).ContinueWith ((x) => "The method has finished it's execution after waiting for " + delay + " seconds");
		}
		public static async Task<String> Approach1(int delay)
		{
			var response = await AsyncMethod1 (delay); // await just unwraps Task's result
			return "Here is the result of AsyncMethod1 operation: '" + response + "'";
		}
		public static Task<String> Approach2(int delay)
		{
			return AsyncMethod2(delay).ContinueWith(message => "Here is the result of AsyncMethod2 operation: '" + message.Result + "'");
		}
		public static void Main (string[] args)
		{
			// You have long running operations that doesn't block current thread
			var operation1 = Approach1 (3); // So as soon as the code hits "await" the method will exit and you will have a "operation1" assigned with a task that finishes as soon as delay is finished
			var operation2 = Approach2 (5); // The same way you initiate the second long-running operation. The method also returns as soon as it hits "await"
			// You can create chains of operations:
			var operation3 = operation1.ContinueWith(operation1Task=>Console.WriteLine("Operation 3 has received the following input from operation 1: '" + operation1Task.Result + "'"));
			var operation4 = operation2.ContinueWith(operation2Task=>Console.WriteLine("Operation 4 has received the following input from operation 2: '" + operation2Task.Result + "'"));
			var operation5 = Task.WhenAll (operation3, operation4)
				.Then(()=>Task.Delay (TimeSpan.FromSeconds (7)))
				.ContinueWith((task)=>Console.WriteLine("After operation3 and 4 have finished, I've waited for additional seven seconds, then retuned this message"));
			Task.WaitAll (operation1, operation2); // This call will block current thread;
			operation3.Wait (); // This call will block current thread;
			operation4.Wait (); // This call will block current thread;
			operation5.Wait (); // This call will block current thread;
			Console.WriteLine ("All operations are completed");
		}
	}
