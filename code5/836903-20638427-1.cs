    List<PrimaryKeyModel> keys = new List<PrimaryKeyModel>()
    {
            new PrimaryKeyModel("Id", "3", 1),
            new PrimaryKeyModel("Id2", "1", 1),
            new PrimaryKeyModel("Id", "1", 2),
            new PrimaryKeyModel("Id2", "1", 2),
            new PrimaryKeyModel("Id", "3", 3),
            new PrimaryKeyModel("Id2", "1", 3),
    };
    
    var groupedKeys = keys.OrderBy(pk => pk.ColumnName).GroupBy(k => k.RowNumber).ToList();
    HashSet<int> duplicateRowNumbers = new HashSet<int>();
    
    for (int i = 0; i < groupedKeys.Count - 1; i++)
    {
        for (int j = i + 1; j < groupedKeys.Count; j++)
    	{
            if (AreTheSame(groupedKeys[i], groupedKeys[j]))
            {
                duplicateRowNumbers.Add(groupedKeys[i].First().RowNumber);
                duplicateRowNumbers.Add(groupedKeys[j].First().RowNumber);
            }
    	}
    }
    private static bool AreTheSame(IEnumerable<PrimaryKeyModel> a, IEnumerable<PrimaryKeyModel> b)
    {
        var leftEnumerator = a.GetEnumerator();
        var rightEnumerator = b.GetEnumerator();
        while (leftEnumerator.MoveNext() | rightEnumerator.MoveNext())
        {
            if (leftEnumerator.Current == null) return false;
            if (rightEnumerator.Current == null) return false;
            if (leftEnumerator.Current.ColumnValue != rightEnumerator.Current.ColumnValue) return false;
        }
    
        return true;
    }
