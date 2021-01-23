	using (MySqlCommand cmd = new MySqlCommand(string.Format("CREATE DATABASE {0} ;", aName), connection))
	{
		cmd.ExecuteNonQuery();          // Create the database with the given user name
		// Building the sql query that will return a "create table" per table in some_db template DB.
		cmd.CommandText = (string.Format("SELECT CONCAT (\"CREATE TABLE {0}.\", TABLE_NAME ,\" "
										   + "LIKE some_other_db.\", TABLE_NAME ) as creation_sql "
										   + "FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'some_db';"
										, aName));
		try     // Building the inner tables "create table" sql strings
		{
			using (MySqlDataReader reader = cmd.ExecuteReader())
			{
				while (reader.Read())
					createInnerTablesList.Add(reader.GetString(0));
			}
		}
		catch (MySqlException mysql_ex) { ... } // handle errors 
		foreach (var sql_insert_query in createInnerTablesList)
		{
			try                         // Insert the tables into the user database
			{
				cmd.CommandText = sql_insert_query;
				cmd.ExecuteNonQuery();
			}
			catch (Exception e) { ... } // handle errors 
		}
	} 
