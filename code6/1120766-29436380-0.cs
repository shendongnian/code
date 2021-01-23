	class Program
	{
		static void Main(string[] args)
		{
			Test t = new Test();
			HashSet<string> a = new HashSet<string>();
			List<string> b = new List<string>();
			if (t.GetString(ref a))
			{
			}
			if (t.GetString(ref b))
			{
			}
		}
		public class Test
		{
			public bool GetString<T>(ref T cont) where T : ICollection<string>
			{
				string foo = "BAR";
				cont.Add(foo); // T does not contain a definition for Add ...
				return true;
			}
		}
	}
