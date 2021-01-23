    public DataTable test(DataTable myTable)
        {
            var results = myTable.AsEnumerable().Distinct().CopyToDataTable() ;
            return results;
        }
