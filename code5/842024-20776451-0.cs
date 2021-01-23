    public void Update()
    {
        string commandostring = "UPDATE Movies SET " +
                                "name = ?,releaseDate = ?,lenghtInMinutes = ? " +
                                "WHERE movieId = ?";
        using(OleDbConnection conn = new OleDbConnection(connectionString))
        using(OleDbCommand command = new OleDbCommand(commandostring, conn))
        {
             conn.Open();
             command.Parameters.AddWithValue("@p1",this.name);
             command.Parameters.AddWithValue("@p2",this.releaseDate);
             command.Parameters.AddWithValue("@p3",this.lenghtInMinutes);
             command.Parameters.AddWithValue("@p4",this.movieId);
             command.ExecuteNonQuery();
        }
    }
