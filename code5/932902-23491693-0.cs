    public static class DataTableExtensions
    {
       public static IEnumerable<DataRow> RowsAsEnumerable ( this DataTable source )
            {
                return (source != null) ? source.Rows.OfType<DataRow>() : Enumerable.Empty<DataRow>();
            }
    }
