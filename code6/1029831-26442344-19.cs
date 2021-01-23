	public static class CSVWriter
	{
		public static void write<T>(this IEnumerable<T> e, string file)
		{
			using (System.IO.StreamWriter f = new System.IO.StreamWriter(file))
			{
				foreach (var i in e)
				{
					f.WriteLine(i);
				}
			}
		}
	}
