	using System;
	using System.Linq;
	using System.Collections.Generic;
	public class Program
	{
		public static IEnumerable<string> Y()
		{
			var list = new List<string> {"1","2","3","4","5"};
			foreach(var i in list)
			{
				yield return i;
			}
		}
		
		public static void Main()
		{
			
			
			var ys = Y();
			Console.WriteLine("first ys");
			Console.WriteLine(string.Join(",", ys));
			IEnumerator<string> i = ys.GetEnumerator();
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
			Console.WriteLine(""+i.MoveNext()+": "+i.Current);
		}
	}
