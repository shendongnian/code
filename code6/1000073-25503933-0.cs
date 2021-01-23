    namespace System
    {
        public static class Extensions
        {
            public static void AddColumnAfter(this DataColumnCollection columnCollection, string afterWhichColumn, DataColumn column)
            {
                var columnIndex = columnCollection.IndexOf(afterWhichColumn);
                columnCollection.Add(column);
                columnCollection[column.ColumnName].SetOrdinal(columnIndex + 1);
            }
        }
    }
