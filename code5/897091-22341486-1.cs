    public void SortList<T>(List<T> list, string columnName, SortDirection direction)
    {
        var property = typeof(T).GetProperty(columnName);
        var multiplier = direction == SortDirection.Descending ? -1 : 1;
        list.Sort((t1, t2) => {
            var col1 = property.GetValue(t1);
            var col2 = property.GetValue(t2);
            return multiplier * Comparer<object>.Default.Compare(col1, col2);
        });
    }
