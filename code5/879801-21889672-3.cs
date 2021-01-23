	public class NvelocitySort
	{
		public List<MyObject> Sort(List<MyObject> list, string fieldAndMode, string comparerName)
		{
			fieldAndMode = fieldAndMode.Trim();
			// Split the incoming string to get the field name and sort ascending or descending
			string[] split = fieldAndMode.Split(' ');
			// Set default sort mode
			string mode = "asc";
			// If sort mode not specified, this will be the field name
			string field = fieldAndMode;
			// If sort mode added split length shall be 2
			if (split.Length == 2)
			{
				field = split[0];
				if (split[1].ToLower() == "asc" || split[1].ToLower() == "ascending") mode = "asc";
				if (split[1].ToLower() == "desc" || split[1].ToLower() == "descending") mode = "desc";
			}
			// If length is more than 2 or 0, return same list as passed in
			else if (split.Length > 2 || split.Length == 0)
			{
				return list;
			}
			// Get comparer based on comparer name
			IComparer<string> comparer = (IComparer<string>)Activator.CreateInstance(Type.GetType(string.Format("Namespace.{0}", comparerName)));
			// Choose the sort order
			if (mode == "asc")
				return list.OrderBy(item => item.GetReflectedPropertyValue(field), comparer).ToList();
			if (mode == "desc")
				return list.OrderByDescending(item => item.GetReflectedPropertyValue(field), comparer).ToList();
			// If sort order not asc/desc return same list as passed in
			return list;
		}
	}
