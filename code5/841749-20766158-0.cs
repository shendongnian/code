    connection.Open();
    command.CommandText = "Your Command";
    DataReader.ExecuteQuery();
    if (DataReader.HasRows) {
        while(DataReader.Read()) {
             for(int i = 0; i < DataReader.FieldCount; i++) {
                
                  // You can get the column names and set the label texts now
                  // by making an array of labels like :
                  label[i].Text = DataReader.GetName(i);                      
             }
        }
    }
    
