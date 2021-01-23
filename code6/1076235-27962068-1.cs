    public class DataTableModel
    {
        public int Id;
        public int ParentId;
        public object Value;
    }
    public static class Extensions
    {
        public static List<DataTableModel> ToDataTableModel<TSource>(this List<TSource> sourceList,
            Func<TSource, int> getId, Func<TSource, int> getParentId, Func<TSource,object> getValue)
        {
            var query = from entry in sourceList
                        select new DataTableModel
                        {
                            Id = getId(entry),
                            ParentId = getParentId(entry),
                            Value = getValue(entry)
                        };
            return query.ToList();
        }
        public static DataTable ToDataTable<TSource>(this List<TSource> list)
        {
            DataTable table = new DataTable();
            foreach (var prop in typeof(TSource).GetType().GetProperties())
            {
                table.Columns.Add(prop.Name, prop.GetType());
            }
            foreach (var entry in list)
            {
                var row = table.NewRow();
                foreach (var prop in typeof(TSource).GetType().GetProperties())
                {
                    row[prop.Name] = prop.GetValue(entry) ?? DBNull.Value;
                }
            }
            return table;
        }
    }
