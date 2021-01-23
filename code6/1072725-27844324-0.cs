    public DataTable RemoveDuplicates<T>(DataTable dt, string keyField)
    {
        IEnumerable<DataRow> uniqueContacts = dt.AsEnumerable()
                            .GroupBy(x => x.Field<T>(keyField))
                            .Select(g => g.First());
        DataTable dtOut = uniqueContacts.CopyToDataTable();
        return dtOut;
    }
