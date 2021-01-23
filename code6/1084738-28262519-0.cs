    public void userName()
    {
         String name = "";
    
         SqlCommand thisCommand = cn.CreateCommand();
         thisCommand.CommandText = "Select * from person;";
    
         cn.Open();
    
         SqlDataReader reader = thisCommand.ExecuteReader();
    
         while (reader.Read())
         {
            name = reader.GetString(0);
         }
    
         myinput.Attributes["placeholder"] = name;
    }
    
