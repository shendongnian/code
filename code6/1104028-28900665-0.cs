    public TOut ExecuteCommand<TOut>(IDbCommand command, Func<IDataReader, TOut> mapHelper)
    {
        TOut result = default(TOut);
        try
        {
            using (connection)
            {
                using (command)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.Default))
                    {
                       return result = mapHelper(reader);
                    }
                }
            }
        }
        catch (Exception _exp)
        {
            throw new Exception("Error!" + _exp.Message);
        }
        
    }
