    SQLiteConnection connection = new SQLiteConnection("Data Source=" + path);
    
    connection.Open();
    
    SQLiteDataReader reader = new SQLiteCommand(connection) { CommandText = "select * from message" }.ExecuteReader();
    
    bool needHeader = true;
    while (reader.Read())
    {
    	// show header if this is the first row
    	if(needHeader){
    		ShowHeader(reader);
    		needHeader = false;
    	}
        //...
    }
    
    reader.Close();
    connection.Close();
    
    void ShowHeader(SQLiteDataReader reader){
    	for (int i=0;i < reader.FieldCount;i++) 
        { 
          string fieldName = reader.GetName(i); 
    	  // use your display method here
          Console.Write(fieldName+"\t"); 
        }         
    }
