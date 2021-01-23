    using System;
	using System.Collections.Generic;
	using System.Linq;
	 
	public class Test
	{
		public static void Main()
		{
			List<int> numbers = new List<int>();
			numbers.Add(1);
			numbers.Add(2);
			numbers.Add(3);
			numbers.Add(4);
			numbers.Add(5);
			numbers.Add(6);
			numbers.Add(7);
			 
			Random rand = new Random();
			 
			var numbersSfle = numbers.OrderBy(item => rand.Next()).ToList();
			Console.Write(numbersSfle[0].ToString());
			numbers.RemoveAt(0);
			 
			 
			numbersSfle = numbers.OrderBy(item => rand.Next()).ToList();
			Console.Write(numbersSfle[0].ToString());
			numbers.RemoveAt(0);
		}
	}
