    public int ExecuteSomeStoredProcudure( out DataTable dataTable )
    {
        int rc ;
        string connectionString = GetConnectionString() ;
        using ( SqlConnection conn = new SqlConnection(connectionString))
        using ( SqlCommand cmd = conn.CreateCommand() )
        using ( SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.CommandText = "someStoredProcedure" ;
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open() ;
            dataTable = new DataTable();
            rc = sda.Fill(dataTable) ;
            conn.Close() ;
        }
        return rc ;
    }
