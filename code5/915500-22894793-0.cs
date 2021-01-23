	class Program
	{
		static void Main(string[] args)
		{
			List<int> list = new List<int> { 1, 2, 3, 4 };
			IEnumerable<IEnumerable<int>> result = GetKCombs(list, 2);
			foreach (var line in result)
			{
				foreach (var item in line)
				{
					Console.Write("{0}, ", item);
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}
		static IEnumerable<IEnumerable<T>> GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
		{
			if (length == 1) return list.Select(t => new T[] { t });
			return GetKCombs(list, length - 1)
				.SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
					(t1, t2) => t1.Concat(new T[] { t2 }));
		}
	}
