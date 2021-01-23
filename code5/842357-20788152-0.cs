	using System;
	using System.Text.RegularExpressions;
	
	public class Test
	{
		public static void Main()
		{
			Regex rex = new Regex("[^a-zA-Z0-9]+");
			
			Console.WriteLine(rex.Replace("asd123!-<>@;',.", ""));
		}
	}
