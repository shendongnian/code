    public List<DataTable> retTable()
    {
        DataSet dt = new DataSet();
        adap.Fill(ds);
        List<DataTable> lst = new List<DataTable>();
        lst.AddRange(ds.Tables.AsEnumerable());
        return lst;
    }
