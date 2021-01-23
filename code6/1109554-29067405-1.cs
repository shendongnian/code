    public static string[] JoinMultiple(string delimiter, List<string[]> lists)
	{
        int maxListLength = lists.Max(l => l.Count());
		string[] result = new string[maxListLength];
		for (int i = 0; i < maxListLength; i++)
		{
		    result[i] = String.Join(delimiter,
                lists.Select(l => (i < l.Count()) ? l[i] : null)
                     .Where(s => s != null));
		}
		return result;
	}
