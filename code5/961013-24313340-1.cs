    private void checkTable()
    {
        string tableName = quotenameTxt.Text + "-" + firstTxt.Text + "-" + surenameTxt.Text;
        string connStr = @"Data Source=|DataDirectory|\LWADataBase.sdf";
        
        using (SqlCeConnection conn = new SqlCeConnection(connStr))
        {
            bool isTableExist = conn.GetSchema("Tables")
                                    .AsEnumerable()
                                    .Any(row => row[2] == tableName);
        }
        
        if (!isTableExist)
        {
            MessageBox.Show("No such data table exists!");
        }
        else
        {
            MessageBox.Show("Such data table exists!");
        }
    }
