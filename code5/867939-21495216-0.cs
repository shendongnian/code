    public interface diNonTransactional
    {
        int ExecuteDataAdapterDataTableWithParams<TDataTable>(IDbCommand podbCommand, ref TDataTable pdtDataTable)
            where TDataTable : DataTable;
    }
