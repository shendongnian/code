/// <summary>
        /// This method is used to merge a set of data tables, based on common columns between them both
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        public static DataTable MergeDataTables(DataTable dt1, DataTable dt2)
        {
            try
            {
                // Get common columns
                var commonColumns = dt1.Columns.OfType<DataColumn>().Intersect(dt2.Columns.OfType<DataColumn>(), new DataColumnComparer());
                // Create the result which is going to be sent to the user
                DataTable result = new DataTable();
                // Add all the columns from both tables
                result.Columns.AddRange(
                    dt1.Columns.OfType<DataColumn>()
                    .Union(dt2.Columns.OfType<DataColumn>(), new DataColumnComparer())
                    .Select(c => new DataColumn(c.Caption, c.DataType, c.Expression, c.ColumnMapping))
                    .ToArray());
                 
                // Add the records of each data table to the new data table, based on the columns
                var rowData = dt1.AsEnumerable().Join(
                    dt2.AsEnumerable(),
                    row => commonColumns.Select(col => row[col.Caption]).ToArray(),
                    row => commonColumns.Select(col => row[col.Caption]).ToArray(),
                    (row1, row2) =>
                    {
                        var row = result.NewRow();
                        row.ItemArray = result.Columns.OfType<DataColumn>().Select(col => row1.Table.Columns.Contains(col.Caption) ? row1[col.Caption] : row2[col.Caption]).ToArray();
                        return row;
                    },
                    new ObjectArrayComparer());
                // Loop and add
                foreach (var row in rowData)
                    result.Rows.Add(row);
                // Return result...
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem while merging data tables. Check that there are common columns between the 2 data tables. Error : " + ex.Message);
            }
        }
