    public DataTable GetValueFromDatabase(string query)
    {
        const string connectionString = "Data Source=DatabaseName;Version=3;";
        using(var ds = new DataSet())
        {
            using(var da = new SQLiteDataAdapter(query, connectionString))
            {
                using(var tran = new TransactionScope())
                {
                    ds.Clear();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    tran.Complete();
                    return dt;
                }
            }
        }
    }
