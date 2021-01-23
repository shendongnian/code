    public void SortByName(List<Column> sortedIncompleteList)
    {
        columnList = columnList
           .OrderBy(c => {
               int index = sortedIncompleteList.FindIndex(c2 => c.FieldName == c2.FieldName);
               if (index == -1) return int.MaxValue;
               return index;
           })
           .ToList();
    }
