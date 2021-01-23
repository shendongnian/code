	class Program
	{
		static void Main(string[] args)
		{
			var list = new List<int>();
			for (int i = 0; i < 100; i++)
			{
				list.Add(i);
			}
			var runningIndex = 0;
			Task.Factory.StartNew(() => Action(ref runningIndex));
			Parallel.ForEach(list, i =>
			{
				runningIndex ++;
				Console.WriteLine(i);
				Thread.Sleep(3000);
			});
			Console.ReadKey();
		}
		private static void Action(ref int number)
		{
			while (true)
			{
				Console.WriteLine("worked through {0}", number);
				Thread.Sleep(2900);
			}
		}
	}
