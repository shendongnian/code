    private static IEnumerable<int> IndexesWhereThereIsOneInTheColumn(
        IEnumerable<List<int>> myIntsGrid)
    {
        int index = 0;
		foreach (var row in myIntsGrid)
		{
			if (row.Contains(1)) yield return index;
			index++;
		}
    }
