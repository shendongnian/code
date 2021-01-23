    public List<DataTable> SplitOnColumnCount(DataTable inputTable, int columnCount)
        {
            if (inputTable == null || columnCount < 1)
            {
                return null;
            }
            var tableList = new List<DataTable>();
            var grouping = Convert.ToInt32(Math.Ceiling((inputTable.Columns.Count) / ((double)columnCount)));
            var columnNames = inputTable.Columns.Cast<DataColumn>().Select(_ => _.ColumnName).ToArray();
            for (var i = 1; i <= grouping; i++)
            {
                var columnsThisTime = columnNames.Skip((i - 1) * columnCount).Take(columnCount).ToArray();
                var newTable = inputTable.Copy();
                var removingColumns = columnNames.Where(_ => columnsThisTime.All(keep => keep != _));
                foreach (var columnName in removingColumns)
                {
                    newTable.Columns.Remove(columnName);
                }
                newTable.AcceptChanges();
                tableList.Add(newTable);
            }
            return tableList;
        }
