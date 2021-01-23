    public static string SingleSQL(string SQL)
    {
    
        SqlConnection SQLCON = new SqlConnection(ConfigurationManager.ConnectionStrings["PIDDBConnectionString"].ToString());
    
        SqlCommand SQLCommand = new SqlCommand();
        SQLCommand.Connection = SQLCON;
        SQLCommand.CommandType = CommandType.Text;
    
        SQLCommand.CommandText = SQL;
        try
        {
           SQLCON.Open();
           return (String)SQLCommand.ExecuteScalar();
        } finally {
           if (SQLCON.State != ConnectionState.Closed) SQLCON.Close();
        }
    }
