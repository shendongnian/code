    public DataSet GetHouse(int ID)
    {
        string sql = "SELECT `ID`, `lat` , `long` FROM `house` WHERE ID= ?ID ";
        DataSet result = new DataSet();
        using (var cn = new MySqlConnection(connectionString) )
        using (var cmd = new MySqlCommand(sql, cn) )
        using (var da = new MySqlDataAdapter(cmd) )
        {
           cmd.Parameters.Add("?ID", MySqlDbType.Int32).Value = ID;
           da.Fill(result);
        }
        return result;
    }
