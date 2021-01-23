	public class ArrayComparer<T> : IEqualityComparer<T[]>
	{
		public bool Equals(T[] ts0, T[] ts1)
		{
			return ts0.SequenceEqual(ts1);
		}
		
		public int GetHashCode(T[] ts)
		{
			return ts.Aggregate(0, (a, t) => (a >> 2) + t.GetHashCode());
		}
	}
