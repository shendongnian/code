    public DataTable SelectTopRows(DataTable dt, int count)
    {
    DataTable dtnew  = dt.Clone();
    for (int i = 0; i < count; i++)
    {
        dtnew.ImportRow(dt.Rows[i]);
    }
    return dtnew ;
