	class Program
	{
		static void Main(string[] args)
		{
			RunMain();
			// pause long enough for all async routines to complete (10 minutes)
			System.Threading.Thread.Sleep(10 * 60 * 1000);
		}
		private static async void RunMain()
		{
			// with await this will pause for poetry
			await Poetry();
			// without await this just runs
			// Poetry();
			for (int main = 0; main < 25; main++)
			{
				System.Threading.Thread.Sleep(10);
				Console.WriteLine("MAIN [" + main + "]");
			}
		}
		private static async Task Poetry()
		{
			await Task.Delay(10);
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("IN THE POETRY ROUTINE [" + i + "]");
				System.Threading.Thread.Sleep(10);
			}
		}
	}
