    private static DataTable ReadFirma()
    {
        string queryString = "SELECT rocnik from FIRMA";
        using (var connection = 
            new SqlConnection(myConnection.DataSource.ConnectionString))
        using(var command = new SqlCommand(queryString, connection))
        {
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(dt);
            return dt;
        }
    }
    
    
    void SomeMethod()
    {
        this.klientTableAdapter.Fill(ReadFirma());
    }
