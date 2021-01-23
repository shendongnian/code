	public class MyComparer : IComparer<object>
	{
		public int Compare(object x, object y)
		{
			throw new NotImplementedException();
		}
	}
		public static void Sort<T>(ref List<T> list, string propertyName)
		{
			list = list.OrderByDescending<T, object>(x => x.GetType().GetProperty(propertyName).GetValue(x, null), new MyComparer()).ToList();
		}
