    public void ReaderExecuting(DbCommand command,
                                DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        if (!string.IsNullOrEmpty(_schemaName))
        {
            command.CommandText = command.CommandText
                                         .Replace("[dbo].", _schemaName);
            interceptionContext.Result = command.ExecuteReader();
        }
    }
