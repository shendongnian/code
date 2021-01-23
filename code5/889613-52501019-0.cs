	using System;
	using System.Threading.Tasks;
						
	public class Program
	{
		public static void Main()
		{
			Task i = CreateTask();
			Task<object> o = Convert<object>(i);
			Console.WriteLine(o.Result);
		}
		
		private static async Task<T> Convert<T>(Task task)
		{
			return await ((Task<T>)task);
		}
		
		private static Task CreateTask ()
		{
			return Task.FromResult("Some result" as object);
		}
	}
