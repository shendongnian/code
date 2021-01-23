    public DataTable GetDataTable(string tablename)
    {
        DataTable DT = new DataTable();
        con.Open();
        cmd = con.CreateCommand();
        cmd.CommandText = string.Format("SELECT * FROM {0}", tablename);
        adapter = new SQLiteDataAdapter(cmd);
        adapter.Fill(DT);
        con.Close();
        DT.TableName = tablename;
        return DT;
    }
