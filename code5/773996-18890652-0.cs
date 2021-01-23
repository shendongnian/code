	using System;
	using System.ComponentModel.Composition;
	using System.ComponentModel.Composition.Hosting;
	using System.Reflection;
	namespace ForStackOverflow
	{
		public class Program
		{
			public static void Main(string[] args)
			{
				var container = new CompositionContainer(
					new AssemblyCatalog(Assembly.GetExecutingAssembly()));
				// Comment out this next line to get an
				// ImportCardinalityMismatchException error
				container.ComposeExportedValue("Age", 30); 
				var person = container.GetExportedValue<Person>();
				Console.WriteLine("Persons age: " + person.Age);
				Console.WriteLine("[press any key to continue]");
				Console.ReadKey();
			}
		}
		[Export]
		public class Person
		{
			[ImportingConstructor]
			public Person()
			{
			}
			[Import("Age")]
			public int Age { get; set; }
		}
	}
