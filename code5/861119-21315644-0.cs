            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        using (var conn = GetConnection())
                        {
                                    string query = 
                      @"some query that may contain transaction itself 
                      or some SP whith transaction included"
                                    using (var command = new SqlCommand(query, conn))
                                        command.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException ex)
                    {
                        // log SQL Exception, if any
                        throw;  // re-throw exception
                    }
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                // we can get here even if scope.Complete() was called.
                // log TransactionAborted exception if necessary
            }
