    using System;
	using System.Collections.Generic;
	
	public class Program
	{
		public static void Main()
		{
			var dictionary = new Dictionary<string, Person>();
			
			Console.Write("How many persons you want to add?: ");
			int p = int.Parse(Console.ReadLine());
	
			for (int i = 0; i < p; i++)
			{
				dictionary.Add("NewPerson" + i, new Person());
			}
			
            // You can access them like this:
			dictionary["NewPerson1"].Name = "Tim Jones";
            dictionary["NewPerson2"].Name = "Joe Smith";
		}
		
		public class Person
		{
			public string Name {
				get; 
				set;
			}
		}
	}
