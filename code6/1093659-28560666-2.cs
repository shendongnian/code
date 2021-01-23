        bool recordExists = false;
        string strConn = ConfigurationManager.ConnectionStrings["MyDBConfig"].ConnectionString;
        SqlConnection oSqlConnection = new SqlConnection(strConn);
        oSqlConnection.Open();
        string commandText = @"SELECT COUNT (*) FROM csvs WHERE Agency='BBB'";
        using (var command = new SqlCommand(commandText, oSqlConnection))
        {
            int recCnt = Convert.ToInt32(command.ExecuteScalar());
            if (recCnt > 0)
                 recordExists = true;
        }
