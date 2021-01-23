    for (int i=0; i < MaximumNumberOfRetries; ++i) {
        try {
        }
        catch (SqlException e) {
            if (e.Errors.Cast<SqlError>().All(x => CanRetry(x))) {
                // What to do? Handle that here, for Class < 20 you
                // may simply Thread.Sleep(DelayOnError);
     
                continue;
            }
    
            throw;
        }
    }
