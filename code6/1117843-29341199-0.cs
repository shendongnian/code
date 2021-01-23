	public class ListCompare<T> : IEqualityComparer<List<T>>
	{
		public bool Equals(List<T> left, List<T> right)
		{
			return left.SequenceEqual(right);
		}
		
		public int GetHashCode(List<T> list)
		{
			return list.Aggregate(0, (a, t) => a ^ t.GetHashCode());
		}
	}
