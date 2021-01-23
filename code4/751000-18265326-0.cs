    public OleDbConnection OpenConnection()
    {
          var result = new OleDbConnection("My special connection string here"))
         result.Open()
         return result;
     }
    public List<string> void DoSomethingWithConnection()
     {
        using (var connection = OpenConnection());
        {
            List<string> dataList = new List<string>();
            OleDbCommand command = new OleDbCommand("DoSomethingHere", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                dataList.Add(reader[0].ToString());
            }
            
            return dataList;
        // The connection is automatically closed when the 
        // code exits the using block.
        }
    }
