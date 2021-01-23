	using System;
	using System.Threading;
	public class Program
	{
		public static void Main()
		{
			var th = new Thread(new ThreadStart(() =>
			{
				Method1();
				Method2();
			}
			));
			th.Start();
			th.Join();
		}
		static void Method1()
		{
			Console.WriteLine("Method 1");
		}
		static void Method2()
		{
			Console.WriteLine("Method 2");
		}
	}
