    public static class SqlExtensions
    {
        public static DataTable ToSqlArray(this IEnumerable<string> collection)
        {
            var dt = new DataTable("ArrayOfString");
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            
            foreach(var item in collection)
            {
                var row = dt.NewRow();
                row[0] = item;
                dt.Rows.Add(row);
            }
            
            return dt;
        }
    }
