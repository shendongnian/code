    private static Dictionary<string, SqlCommand>  parameterizedCommands = new Dictionary<string,SqlCommand>();
    public static void CreateparameterizedCommandsy(string[] colums)
    {
        parameterizedCommands = new Dictionary<string,SqlCommand>();
        foreach (string colname in colums)
        {
            parameterizedCommands.Add(colname, CreateCommandForColumn(colname));
        }
    }
    public static SqlCommand CreateCommandForColumn(string columnName)
    {
        SqlCommand myCommand = new SqlCommand(string.Format("UPDATE Events SET {0} = @truefalse WHERE Name = @name",columnName));
        // the following statement creates the parameter in one go. Bit = boolean
        myCommand.Parameters.Add("@truefalse", SqlDbType.Bit);
        myCommand.Parameters.Add("@name", SqlDbType.Text);
        return myCommand;
    }
    public int ExccuteColumnUpdate(string columnName, bool setToValue, string name, SqlConnection connection)
    {
        connection.Open();
        try
        {
            SqlCommand command;
            if (parameterizedCommands.TryGetValue(columnName, out command))
            {
                command.Connection = connection;
                command.Parameters["@truefalse"].Value = setToValue;
                command.Parameters["@name"].Value = name;
                return command.ExecuteNonQuery();
            }
        }
        finally
        {
            connection.Close();
        }
        return 0;
    }
