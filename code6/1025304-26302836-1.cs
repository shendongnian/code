    connection.Open()
    OleDBCommand command = new OleDbCommand();
    command.Connection = connection;
    command.CommandText = "SELECT EID From Table";
    using (OleDbDataReader dr = command.ExecuteReader())
    {
        while (dr.read())
        {
            //new connection
            for(var i = 0;i < 10;i++)
            {  
                //insert (int)dr["EID"] into 2nd table
            }
    
        }
    }
