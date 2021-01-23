    public virtual IDataReader LoadDataReaderWithSqlString(string strQuery, ISessionScope session)
    {
        try 
        {
            var s = GetSession(session);
            var connection = s.Connection;
        
            var command = connection.CreateCommand();
            command.Connection = connection;
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = s.CreateSQLQuery(strQuery).ToString();
            s.Transaction.Enlist(command); // Set the command to exeute using the NHibernate's transaction
            
            try
            {
                var dataReader = command.ExecuteReader();
                if(dataReader.Read())
                    return dataReader;
            }
            catch (DbException)
            { 
                // error executing command
                connection.Close();
                return null; // or throw; // it depends on your logic
            }
        }
        catch (DbException)
        {
            // if connection was not opened
            return null; // or throw; // it depends on your logic
        }
        return null;
    }
