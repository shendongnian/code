    public class ReportCell
    {
        public int RowId { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
    
        public static List<ReportCell> ConvertTableToCells(DataTable table)
        {
            List<ReportCell> cells = new List<ReportCell>();
    
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    ReportCell cell = new ReportCell
                    {
                        ColumnName = col.Caption,
                        RowId = table.Rows.IndexOf(row),
                        Value = row[col.ColumnName].ToString()
                    };
    
                    cells.Add(cell);
                }
            }
    
            return cells;
        }
    }
