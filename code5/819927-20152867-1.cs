    using (var cnx = new SqlConnection(pubvar.x))
    using (var cmd = new SqlCommand
    {
    	Connection = cnx,
    	CommandText = @"
    	insert into A (Name) values (@name)
    	insert into B (A_ID, Rate) values (scope_identity(), @rate)
    	",
    	Parameters =
    	{
    		new SqlParameter("@name", name),
    		new SqlParameter("@rate", .5m) //sample rate
    	}
    })
    {
    	cmd.ExecuteNonQuery();
    }
