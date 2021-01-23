	public class StringByCharComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			var xcs = x.ToCharArray();
			var ycs = y.ToCharArray();
			return Compare(xcs, ycs);
		}
		
		private int Compare(IEnumerable<char> xs, IEnumerable<char> ys)
		{
			if (!xs.Any() || !ys.Any())
			{
				return 0;
			}
			else
			{
				var x = xs.First();
				var y = ys.First();
				var r = x.CompareTo(y);
				if (r == 0)
				{
					r = Compare(xs.Skip(1), ys.Skip(1));
				}
				return r;
			}
		}
	}
