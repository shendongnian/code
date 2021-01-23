    public DataTable GetDeity()
    {
    DataTable mTable = new DataTable();
    
    cmd = new SqlCommand();
    cmd.Connection = conDB;
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "get_DeityMaster";
    
    SqlAapter mAdapter = new SqlAdapter(cmd);
    mAdapter.Fill(mTable);
    
    return mTable
    }
