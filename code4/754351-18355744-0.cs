    private static int ReadFirma()
    {
        string queryString = "SELECT rocnik from FIRMA";
        using (var connection = 
            new SqlConnection(myConnection.DataSource.ConnectionString))
        using(var command = new SqlCommand(queryString, connection))
        {
            connection.Open();
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }
    void SomeMethod()
    {
        this.klientTableAdapter.Fill(ReadFirma());
    }
    
