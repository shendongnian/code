	using System;
	using System.Collections.Generic;
	using ConsoleApplication1.ServiceReference1;
	namespace ConsoleApplication1
	{
		internal class Program
		{
			private static void Main()
			{
				using (var service = new Service1Client())
				{
					// Add items...
					int itemCount;
					itemCount = service.AddData("Test Item 1");
					Console.WriteLine("Service now holds {0} items", itemCount);
					itemCount = service.AddData("Test Item 2");
					Console.WriteLine("Service now holds {0} items", itemCount);
					itemCount = service.AddData("Test Item 3");
					Console.WriteLine("Service now holds {0} items", itemCount);
					// Get all of the items added...
					List<string> listFromService = service.GetData();
					foreach (var listItem in listFromService)
					{
						Console.WriteLine("  * {0}", listItem);
					}
					Console.WriteLine();
				}
				Console.ReadKey();
			}
		}
	}
