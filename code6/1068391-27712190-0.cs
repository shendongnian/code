    using (var connection = new OracleConnection(connectionString))
    {
        using (var transaction = connection.BeginTransaction())
        {
            connection.Open();
            //...log-2...
            using (var cmd = connection.CreateCommand())
            {
                foreach (var parserItem in parserItems.GetConsumingEnumerable(cancellationTokenSource.Token))
                {
                    if (!cancellationTokenSource.IsCancellationRequested)
                    {
                        try
                        {
                            foreach (var statement in ProcessRecord(parserItem))
                            {
                                cmd.CommandText = statement;
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (OracleException ex)
                                {
                                    //...log-4...
                                    if (!acceptedErrorCodes.Contains(ex.ErrorCode))
                                    {
                                        log.Warn(ex.Message);
                                    }
                                }
                            }
                        }
                        catch (FormatException ex)
                        {
                            log.Warn(ex.Message);
                        }
                    }
                }
                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                    throw new Exception("DBComponent has been canceled");
                }
            }
        }
    }
    //...log-9... 
