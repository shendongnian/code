    public static class DataTableExtensions
    {
        public static IEnumerable<Double> Values(this DataTable dt, DataColumn column)
        {
           return dt.AsEnumerable().Select(x => x.Field<double>(column.ColumnName));
        }
    }
