    YourGrid.DataSource = Refresh("SELECT...");
    private BindingSource Refresh(string sql)
    {
        try
        {
            using (var da = new SqlDataAdapter(sql, new SqlConnection(Properties.Settings.Default.ConnectionString)) { FillLoadOption = LoadOption.Upsert })
            {
                da.SelectCommand.Connection.Open();
                da.Fill(dataSet.YourTable);
            }
        }
        catch(Exception ex) { MessageBox.Show(ex.Message); }
        return new BindingSource(dataSet, "YourTable");
    }
