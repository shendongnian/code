	public class AfterTwenty : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			if (x == null)
			{
				return y == null;
			}
			return x.Substring(20) == y.Substring(20);
		}
		public int GetHashCode(string obj)
		{
			return obj == null ? 0 : obj.Substring(20).GetHashCode();
		}
	}
