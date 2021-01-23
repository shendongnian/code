    string sqlQuery = "INSERT into EndResultOfTestCases(IDsOfCases,TestCaseName,ResultCase,ResultLog) VALUES(@ids, @casename, @results, @logs)";
            connection = new OleDbConnection(connectionStringToDB);
            command = new OleDbCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@ids",IDs);
            command.Parameters.AddWithValue("@casename", CaseName);
            command.Parameters.AddWithValue("@results", resultOfCase);
            command.Parameters.AddWithValue("@logs", logs);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
