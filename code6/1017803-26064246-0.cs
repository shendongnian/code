    var distinct = list.Distinct(new CaseInsensitiveComparer());
	public class CaseInsensitiveComparer : IEqualityComparer<A>
	{
		public bool Equals(A x, A y)
		{
			return x.Code.Equals(y.Code, StringComparison.OrdinalIgnoreCase) &&
			       x.Description.Equals(y.Description, StringComparison.OrdinalIgnoreCase);
		}
		public int GetHashCode(A obj)
		{
			return obj.Code.ToLowerInvariant().GetHashCode();
		}
	}
