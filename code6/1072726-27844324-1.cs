    public DataTable RemoveDuplicates(DataTable dt, string keyField)
    {
        IEnumerable<DataRow> uniqueContacts = dt.AsEnumerable()
                            .GroupBy(x => x[keyField].ToString())
                            .Select(g => g.First());
        DataTable dtOut = uniqueContacts.CopyToDataTable();
        return dtOut;
    }
