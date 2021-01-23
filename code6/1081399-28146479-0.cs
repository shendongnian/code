    using(SqlConnection con = new SqlConnection(conString))
    using(SqlCommand cmd = con.CreateCommand())
    {
       // Set your CommandText propert of your query.
       // Add your parameter values with SqlParameterCollection.Add() method
       // Open your connection.
       // Execute your query.
    }
