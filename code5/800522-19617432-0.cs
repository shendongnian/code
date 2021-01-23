    private void UpdateDataGrid(SQLiteConnection con, string sql)
    {
        DataSet dataSet = new DataSet();
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, con);
        dataAdapter.Fill(dataSet);
    
        dataGrid.DataSource = dataSet.Tables[0].DefaultView;
    }
