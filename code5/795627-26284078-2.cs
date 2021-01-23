        private static readonly HybridDictionary cache = new HybridDictionary();
        public static object[] GetColumnValues(
            this GridView g, 
            int rownumber, 
            string columnNamesCommaSeparated)
        {
            var dataView = g.DataSource as DataView;
            if (dataView != null)
            {
                DataRow dataRow = dataView[rownumber].Row;
                object[] items = dataRow.ItemArray;
                DataColumnCollection columns = dataRow.Table.Columns;
                string lookupkey = g.ID + columnNamesCommaSeparated;
                var colids = cache[lookupkey] as int[];
                int columnCount;
                if (colids == null)
                {
                    string[] columnNames = columnNamesCommaSeparated.Split(',');
                    columnCount = columnNames.Count();
                    colids = new int[columnCount];
                    for (int i = 0; i < columnCount; i++)
                    {
                        colids[i] = columns.IndexOf(columnNames[i]);
                    }
                    cache.Add(lookupkey, colids);
                }
                columnCount = colids.Length;
                var values = new object[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    values[i] = items[colids[i]] ?? "";
                }
                return values;
            }
            return null;
        }
