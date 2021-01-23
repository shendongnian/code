    bool rebuildConnection = true; // First try connection must be open
    for (int i=0; i < MaximumNumberOfRetries; ++i) {
        try {
            // (Re)Create connection to SQL Server
            if (rebuildConnection) {
            }
  
            // Perform your task
            // No exceptions, task has been completed
            break;
        }
        catch (SqlException e) {
            if (e.Errors.Cast<SqlError>().All(x => CanRetry(x))) {
                // What to do? Handle that here, for Class < 20 you
                // may simply Thread.Sleep(DelayOnError);
     
                rebuildConnection = e.Errors
                    .Cast<SqlError>()
                    .Any(x => x.Class >= 20);
                continue; 
            }
    
            throw;
        }
    }
