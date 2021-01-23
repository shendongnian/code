    if (sqlDataReader.HasRows)
    {
	  while(sqlDataReader.Read())
	  {
		if(!sqlDataReader.IsDBNull(1)) //pass the column index.
		{
			object value=sqlDataReader[1];
		}
	
	  }
     }
