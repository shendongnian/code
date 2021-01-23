    private SqlConnection GetConnection()
    {
        var con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AuthenticationDBConnectionString"].ConnectionString);
        con.Open();
        return con;
    }
    
    protected string InjectUpdateToProductDBString(string Command, TextBox Data, string TBColumn)
    {
        using (var con = GetConnection())
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.Parameters.AddWithValue("@" + TBColumn, Data.Text);
                cmd.ExecuteNonQuery();
                return "Data Succesfully Updated";
            }
        }
    }
