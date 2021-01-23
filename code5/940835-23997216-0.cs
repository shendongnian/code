    public static SqlDataReader ExecuteReader(this SqlCommand command, CommandBehavior commandBehavior, CancellationToken cancel)
    {
        try
        {
            using (cancel.Register(command.Cancel))
                return command.ExecuteReader(commandBehavior);
        }
        catch (SqlException)
        {
            cancel.ThrowIfCancellationRequested();
            throw;
        }
    }
