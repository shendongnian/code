    public List<DataRow> retTable()
    {
    	DataTable dt = new DataTable();
    	adap.Fill(dt);
    	return dt.AsEnumerable().ToList();
    }
