    MySqlConnection connection = new MySqlConnection("");
    MySqlDataAdapter mySqlDataAdapter;
    DataSet DS;
    private string columnValue = "xxx";
    private string Choise =" yyy";
    MySqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM table2 WHERE " + columnValue + " = @choise";
    command.Parameters.Add(new MySqlParameter("@choise", Choise));
    DS = new DataSet();
    connection.Open();
    
    dAdt.Fill(dSet)
    mySqlDataAdapter = new MySqlDataAdapter;
    mySqlDataAdapter .SelectCommand = command;
    mySqlDataAdapter.Fill(DS);
    connection.Close();
