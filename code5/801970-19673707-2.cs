    public class GenerateTable
    {
        public DataTable ExcelTableLines(IEnumerable<MyC> lines)
        {
            var dt = CreateTable();
            foreach (var line in lines)
            {
                var row = dt.NewRow();
                row["AAA"] = line.AAA;
                row["BBB"] = line.BBB;
                row["CCC"] = line.CCC;
                dt.Rows.Add(row);
            }
            return dt;
        }
        private DataTable CreateTable()
        {
            var dt = new DataTable("ExelTable");
            var col = new DataColumn { DataType = typeof(String), ColumnName = "AAA" };
            dt.Columns.Add(col);
            col = new DataColumn { DataType = typeof(String), ColumnName = "BBB" };
            dt.Columns.Add(col);
            col = new DataColumn { DataType = typeof(String), ColumnName = "CCC" };
            dt.Columns.Add(col);
            return dt;
        }
    }
