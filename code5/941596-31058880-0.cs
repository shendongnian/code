	using Fody;
	[ConfigureAwait(false)]
	public class MyAsyncLibrary
	{
		public async Task MyMethodAsync()
		{
			await Task.Delay(10);
			await Task.Delay(20);
		}
		public async Task AnotherMethodAsync()
		{
			await Task.Delay(30);
		}
	}
