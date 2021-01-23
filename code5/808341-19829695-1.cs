    private void LoadData()
    {
        try
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string commandText = "select task from Mine order by id desc limit 1";
    
            sql_cmd.CommandText = commandText;
            var lsattask = sql_cmd.ExecuteScalar().ToString();
    
            MessageBox.Show(lsattask);
    
            sql_con.Close();
        }
        catch(Exception exception)
        {
            Debug.WriteLine(exception.Message);
        }
    }
