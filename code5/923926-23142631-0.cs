    using( SqlConnection conn = new SqlConnection( connectionString ) )
    {
        conn.Open();
        using( SqlCommand command = new SqlCommand( "your select statement", conn ) )
        {
            command.AddWithValue( "@Param1", value-goes-here );
            var reader = command.ExecuteReader();
            // loop over reader and do stuff with the values
        }
    }
