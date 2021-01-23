    private void RunSqlTransaction(string sqlStatement)
    		{
    			//split the script on "GO" commands
    			string[] splitter = new string[] { "\r\nGO\r\n" };
    			string[] commandTexts = sqlStatement.Split(splitter,
    			  StringSplitOptions.RemoveEmptyEntries);
    			foreach (string commandText in commandTexts)
    			{
    			Sql(commandText.Replace("GO", ""));
    			}
    		}
