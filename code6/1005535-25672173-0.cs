    public T LoadDataToReader<T>(string selectCommand, Func<IDataReader,T> ProcessResults)
    {
        string myConnectionString = "Data Source = " + server + "; User = " + user + "; Port = 3306; Password = " + password + ";";
        string useDataBaseCommand = "USE " + dbName + ";";
        using (var myConnection = new MySqlConnection(myConnectionString))
        {
            myConnection.Open();
 
            using (var myCommand = myConnection.CreateCommand())
            {
                myCommand.CommandText = useDataBaseCommand + selectCommand;
  
                using(var myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                   return ProcessResults(myReader);
                }
            }
        }
    }
