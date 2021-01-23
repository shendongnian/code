    public string CekValidData(string data)
    {
        SqlConnection Conn = DataSetting.GetSqlConnection();
        SqlCommand Comm = new SqlCommand();
        try
        {
           Conn.Open();
           string paramData = ParseData(data);
           string sql = @"select NamaDivisi from Divisi where NamaDivisi IN('" + paramData + "')";
           Comm = new SqlCommand(sql, Conn);
           data = Convert.ToString(Comm.ExecuteScalar());
        }
        finally
        {
           Conn.Close();
           Conn.Dispose();
        }
        return data;
    }
    private string ParseData(string data)
    {
        return data.Replace(";", "','");
    }
