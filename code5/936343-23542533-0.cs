    private static IEnumerable<int> GetColumnValues(IEnumerable<int[]> arr, int columnIndex)
    {
        return arr.Select(a => a.Skip(columnIndex).FirstOrDefault());
    }
    ...
    GetColumnValues(jaggedArray, 1).Sum();
