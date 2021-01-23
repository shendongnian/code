    public class DataTableModel
    {
        public int Id;
        public int? ParentId;
        public object Value;
    }
    public static class Extensions
    {
        public static List<DataTableModel> ToDataTableModel<TSource>(this List<TSource> sourceList, Func<TSource, int> getId, Func<TSource, int?> getParentId, Func<TSource,object> getValue)
        {
            var tempList = new List<DataTableModel>();
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
            foreach (var prop in typeof(TSource).GetFields())
            {
                table.Columns.Add(prop.Name, 
                    Nullable.GetUnderlyingType(prop.FieldType) ?? prop.FieldType);
            }
            foreach (var entry in list)
            {
                var row = table.NewRow();
                foreach (var prop in typeof(TSource).GetFields())
                {
                    row[prop.Name] = prop.GetValue(entry) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
