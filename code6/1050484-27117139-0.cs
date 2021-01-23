	class MainClass
	{
		public static async Task<String> AsyncMethod(int delay) {
			await Task.Delay (TimeSpan.FromSeconds(delay));
			return "The method has finished it's execution after waiting for " + delay + " seconds";
		}
		public static async Task Approach1(int delay)
		{
			var response = await AsyncMethod (delay); // await just unwraps Task's result
			Console.WriteLine (response);
		}
		public static Task Approach2(int delay)
		{
			return AsyncMethod(delay).ContinueWith(message => Console.WriteLine(message)); // you could do the same with 
		}
		public static void Main (string[] args)
		{
			var operation1 = Approach1 (3);
			var operation2 = Approach2 (5);
			Task.WaitAll (operation1, operation2);
			Console.WriteLine("All operations are completed")
		}
	}
