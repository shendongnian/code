    using(SqlConnection conn = new SqlConnection(source))
    using(SqlCommand cmd = conn.CreateCommand())
    {
       // Set your CommandText property with parameterized way.
       // Add your parameters with .Add() method
       // Open your connection
       // Execute your query.
    }
