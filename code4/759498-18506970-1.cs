    private static readonly SqlConnection SqlConnection = new SqlConnection("Data Source=server name;Initial Catalog=database name;Persist Security Info=True;User ID= ;Password= ");`
     
    public SqlConnection ServerConnection()
    {
        if (SqlConnection.State == ConnectionState.Open)
        {
            SqlConnection.Close();
        }
        else
        {
            SqlConnection.Open();
        }
        return SqlConnection;
    }
