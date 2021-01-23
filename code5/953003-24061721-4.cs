    using(MySqlConnection connection = new MySqlConnection(conn))
    using(MySqlCommand cmd = connection.CreateCommand())
    {
        cmd.CommandText = "INSERT INTO BOOK(ISBN, title, author, publisher,imgPath, catalogID) VALUES (@isbn, @title, @author, @publisher, @path, @id)";
        ...
        //Add your parameter values one by one.
        connection.Open();
        int rowCount = cmd.ExecuteNonQuery();
        
        if(rowCount == 1) //or you can use > 0
        {
           //Successful
        }
        else
        {
          //Unsuccessfull
        }
    }
