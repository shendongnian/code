    // set up your connection
    MySqlConnection myConnection= new MySqlConnection(strMySqlConnectionString);
    // format your query
    string mySelectQuery = string.Format("SELECT * FROM users WHERE username = '{0}' LIMIT 1", username);
    // initalize your command properly
    MySqlCommand myCommand = new MySqlCommand(mySelectQuery);
    myCommand.CommandType = CommandType.Text;
    // set your connection 
    myCommand.Connection = myConnection;
