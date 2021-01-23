    // set up your connection
    MySqlConnection myConnection= new MySqlConnection(strMySqlConnectionString);
    // format your query
    string mySelectQuery = string.Format("SELECT * FROM users WHERE username = '{0}' LIMIT 1", username);
    // initalize your command properly
    MySqlCommand mCommand = new MySqlCommand(mySelectQuery);
    mCommand.CommandType = CommandType.Text;
    // set your connection 
    mCommand.Connection = myConnection;
