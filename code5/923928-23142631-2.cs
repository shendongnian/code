    using( SqlConnection conn = new SqlConnection( connectionString ) )
    {
        conn.Open();
        using( SqlCommand command = new SqlCommand( "your select statement", conn ) )
        {
            command.AddWithValue( "@Param1", YourTextBox.Text );
            var reader = command.ExecuteReader();
            reader.Read();
            txtFoo.Text = reader["FooColumn"];
            txtBar.Text = reader["BarColumn"];
        }
    }
