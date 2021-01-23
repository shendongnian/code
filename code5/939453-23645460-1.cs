    myCommand = new SqlCommand("SELECT * FROM table
            WHERE Column1=@column1
             AND Column2 =@myColumn2 
             AND Column3 = @myColumn3 
             AND Column4 =@myColumn4", myConnection);
    
      myCommand.Parameters.AddWithValue("@column1", value1);
      myCommand.Parameters.AddWithValue("@myColumn2", value2);
      myCommand.Parameters.AddWithValue("@myColumn3", value3);
      myCommand.Parameters.AddWithValue("@myColumn3", value4);
    
      using(SqlDataReader reader = myCommand.ExecuteReader())
      {
        while(reader.Read())
        {
          //code here
        }
      }
