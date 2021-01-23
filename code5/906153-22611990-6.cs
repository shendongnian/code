    public static ColumnList CreateFrom(ColumnList other)
    {
         var columnList = new ColumnList();
         columnList.AddRange(other.Select(c => new Column { Name = c.Name }));
         return columnList;
    }
