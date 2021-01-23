    public void BorrowMovie(int memberCardNumber)
    {
        string connectionString = @"Data Source=|DataDirectory|\VideoStoreDB.sdf";
        using (SqlCeConnection connection = new SqlCeConnection(connectionString))
        {
    
        connection.Open();
        using (SqlCeCommand command = new SqlCeCommand(
            "UPDATE Customer SET NumberBorrowedMovies = NumberBorrowedMovies+1 " +
            "WHERE MemberCardNR = @mcn)", connection))
        {   
        command.Parameters.AddWithValue("@mcn", memberCardNumber);      
        command.ExecuteNonQuery();
        // connection.Close(); no longer needed
        } // command
        } // connection
        Console.WriteLine("Movie was borrowed!");
        Console.ReadLine();
    }
