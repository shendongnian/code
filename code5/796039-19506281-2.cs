	public class Program
	{
		public static void Main()
		{		
			var test = new Test();
		
			test.Event += test_Event;
			test.Event +=test_Event2;
		
			test.DoneSomethingAsync().Wait();
		}
	}
	
	public delegate Task CustomEvent(object sender, EventArgs e);
	
	private static Task test_Event2(object sender, EventArgs e)
	{
		Console.WriteLine("delegate 2");
		return Task.FromResult(false);
	}
	
	static async Task test_Event(object sender, EventArgs e)
	{
		Console.WriteLine("Del1gate 1");
		await Task.Delay(5000);
		Console.WriteLine("5000 ms later");
	}
	
	public class Test
	{
		public event CustomEvent Event;
		public async Task DoneSomethingAsync()
		{
			var handler = this.Event;
			if (handler != null)
			{
			      var tasks = handler.GetInvocationList().Cast<CustomEvent>().Select(s => s(this, EventArgs.Empty));
			      await Task.WhenAll(tasks);				
			}
		}
	}
