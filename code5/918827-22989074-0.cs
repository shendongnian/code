    public void SomeMethodWhichConnectsToDB()
    {
        using (var connection = new SqlConnection())
            using (var command = new SqlCommand())
            {
                // do something with the connection, execute the command, etc
            }
    }
