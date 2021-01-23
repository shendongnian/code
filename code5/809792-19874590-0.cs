    public class InsertQuery
    {
        private class Column
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        private readonly List<Column> columns = new List<Column>();
        private readonly string tableName;
        public InsertQuery(string tableName)
        {
            this.tableName = tableName;
        }
        public void AddColumn(string name, string value)
        {
            columns.Add(new Column { Name = name, Value = value });
        }
        public string RemoveColumnByName(string columnName)
        {
            var column = columns.First(c => c.Name == columnName);
            var value = column.Value;
            columns.Remove(column);
            return value;
        }
        public string RemoveIdColumn()
        {
            var column = columns.First();
            var value = column.Value;
            columns.RemoveAt(0);
            return value;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append(tableName);
            sb.Append(" (");
            // append first all column names and then their values
            return sb.ToString();
        }
    }
