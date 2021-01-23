    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");
            dt.Rows.Add(1, "first", "A");
            dt.Rows.Add(2, "second", "B");
            var dictTable = DataTableToDictionaryList(dt);
            var rowCount = dictTable.Count;
            var colCount = dictTable[0].Count;
            //Linq version
            var dictTableFromLinq = dt.AsEnumerable().Select(
                    // ...then iterate through the columns...  
                    row => dt.Columns.Cast<DataColumn>().ToDictionary(
                        // ...and find the key value pairs for the dictionary  
                        column => column.ColumnName,    // Key  
                        column => row[column] as string // Value  
                        )
                    ).ToList();
        }
        public static List<Dictionary<string, object>> DataTableToDictionaryList(DataTable dt)
        {
            var result = new List<Dictionary<string, object>>();
            //or var result = new List<Dictionary<string, string>>();
            foreach (DataRow row in dt.Rows)
            {
                var dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dictRow.Add(col.ColumnName, row[col]);
                    //or dictRow.Add(col.ColumnName, row[col].ToString());
                }
                result.Add(dictRow);
            }
            return result;
        }
    }  
