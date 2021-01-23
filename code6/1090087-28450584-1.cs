    public void SortByName(List<Column> sortedIncompleteList)
    {
        columnList = columnList
         .OrderByDescending(c => sortedIncompleteList.Any(c2 => c.FieldName == c2.FieldName))
         .ToList();
    }
