      public static MySqlDataAdapter CreateCustomerAdapter(MySqlConnection conn)
      {
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlCommand cmd;
        MySqlParameter parm;
        // Create the SelectCommand.
        cmd = new MySqlCommand("SELECT * FROM mytable WHERE id=?id AND name=?name", conn);
        cmd.Parameters.Add("?id", MySqlDbType.VarChar, 15);
        cmd.Parameters.Add("?name", MySqlDbType.VarChar, 15);
        da.SelectCommand = cmd;
        // Create the InsertCommand.
        cmd = new MySqlCommand("INSERT INTO mytable (id,name) VALUES (?id,?name)", conn);
        cmd.Parameters.Add("?id", MySqlDbType.VarChar, 15, "id" );
        cmd.Parameters.Add("?name", MySqlDbType.VarChar, 15, "name" );
        
        da.InsertCommand = cmd;  
        return da;
      }
