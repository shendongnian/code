    // Writes.
    using (var connection = new SqlConnection("data source=.; initial catalog=master; Integrated Security=True;"))
    {
        connection.Open();
    
        var command = new SqlCommand("insert into anything (published) values (@published)", connection);
        command.Parameters.AddWithValue("@published", "2014-05-21T17:00:38");
        // Not working as it will throw "Conversion failed when converting date and/or time from character string.".
        //command.Parameters.AddWithValue("@published", "2014-12345-21T17:00:38");
        command.ExecuteScalar();
    }
