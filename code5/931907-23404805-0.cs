	using System;
	using System.Collections.Generic;
	public class MainClass
	{
		public static void Main(string[] args)
		{
			var newDict = new Dictionary<string, string>();
			newDict.Add("a", "x");
			Console.WriteLine(newDict.ContainsKey("a"));
			Console.WriteLine(newDict.ContainsKey("A"));
			newDict.Add("A", "y");
			Console.WriteLine(newDict.ContainsKey("a"));
			Console.WriteLine(newDict.ContainsKey("A"));
			Console.WriteLine(newDict.Count);
		}
	}
