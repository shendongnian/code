        static public IEnumerable<DataColumn> GetColumns(DataTable dt)
        {
            var names = new[] { "foo", "bar" };
            return dt.Columns.OfType<DataColumn>().Where(c => names.Contains(c.ColumnName));
        }
