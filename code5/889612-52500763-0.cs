	using System;
	using System.Threading.Tasks;
	using System.Reflection;
	public class Program
	{
		private static async Task<object> Convert(Task task)
		{
			await task;
			var voidTaskType = typeof (Task<>).MakeGenericType(Type.GetType("System.Threading.Tasks.VoidTaskResult"));
			if (voidTaskType.IsAssignableFrom(task.GetType()))
				throw new InvalidOperationException("Task does not have a return value (" + task.GetType().ToString() + ")");
			var property = task.GetType().GetProperty("Result", BindingFlags.Public | BindingFlags.Instance);
			if (property == null)
				throw new InvalidOperationException("Task does not have a return value (" + task.GetType().ToString() + ")");
			return property.GetValue(task);
		}
		public static async Task Main()
		{
			Console.WriteLine("Start");
			Task i = CreateTask();
			Task<object> o = Convert(i);
			Console.WriteLine("value: {0}", await o);
			Console.WriteLine("value2: {0}", await Convert(Task.FromResult<int>(123)));
			//Test for tasks without return values
			try
			{
				Console.WriteLine("value3: {0}", await Convert(Task.CompletedTask));
			}
			catch (Exception ex)
			{
				Console.WriteLine("value3: EX {0}", ex.Message);
			}
			//Test for tasks without return values
			try
			{
				Console.WriteLine("value4: {0}", await Convert(Test4()));
			}
			catch (Exception ex)
			{
				Console.WriteLine("value4: EX {0}", ex.Message);
			}
			Console.WriteLine("Done");
		}
		private static Task CreateTask()
		{
			return Task.FromResult("Some result");
		}
		public static async Task Test4()
		{
			await Task.CompletedTask;
			return;
		}
	}
