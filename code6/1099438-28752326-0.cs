	using System;
	using System.Collections.Generic;
	using System.Linq;
	namespace ConsoleApplication2
	{
		class Program
		{
			static void Main(string[] args)
			{
				var list = new List<Coord>();
				list.Add(new Coord() { Name = "a", X = 133, Y = 2 });
				list.Add(new Coord() { Name = "d", X = 4, Y = 2 });
				var sum = list.OrderBy(x => x.X + x.Y);
				foreach(var s in sum)
				{
					Console.WriteLine(s.ToString(" "));
				}
				Console.Read();
			}
		}
		class Coord
		{
			public string Name { get; set; }
			public int X { get; set; }
			public int Y { get; set; }
			public string ToString(string sep = "")
			{
				return string.Format("{0}{3}{1}{3}{2}", Name, X, Y, sep);
			}
		}
	}
