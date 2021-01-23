	public static class CharExtensions
	{
		public static string Repeat(this char c, int count)
		{
			return new String(c, count);
		}
	}
	...
	string spaces = ' '.Repeat(10);
