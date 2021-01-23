    public class Class1
    {
        private int id;
        public string name;
        public Class1(DataRow row)
        {
            id = (int)GetColumnValue(row, "id");
            name = (string)GetColumnValue(row, "name");
        }
        public object GetColumnValue(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) ? row[column] : null;
        }
    }
