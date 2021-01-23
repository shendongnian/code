    try
    {
        using (connection)
        {
            cmd.Connection = connection; //Here assign connection to command object
            connection.Open();
            added = cmd.ExecuteNonQuery();
            //update success variable
            success += "\n" + added.ToString() + " records inserted.";
        }//end using(connection)
    }//end try
