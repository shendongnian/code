    public IEnumerable<DataRow> test(DataTable myTable)
        {
            var results = myTable.AsEnumerable().Distinct() ;
            return results;
        }
