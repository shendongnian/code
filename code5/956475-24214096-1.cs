    public class ReliableAzureConnection
    {
        string ConnectionString;
        RetryPolicy RetryPolicy;
        /// <summary>
        /// Initialize the retryPolicy
        /// Load the connection string from App.config
        /// </summary>
        public ReliableAzureConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //This means, 3 retries, first error, wait 0.5 secs and the next errors, increment 1 second the waiting
            Incremental RetryStrategy = new Incremental(3, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
            // You can use one of the built-in detection strategies for 
            //SQL Azure, Windows Azure Storage, Windows Azure Caching, or the Windows Azure Service Bus. 
            //You can also define detection strategies for any other services that your application uses.
            RetryPolicy = new RetryPolicy<StorageTransientErrorDetectionStrategy>(RetryStrategy);
        }
        public DataTable GetTable(string commandText)
        {
            DataTable DataTable = null;
            DataTable TempDataTable = null;
    
            try
            {
                //This is the function that will retry, 
                //dont try to make your retry logic your self! 
                //there are so many error codes. Not all can retry
                RetryPolicy.ExecuteAction(() =>
                {
                    // Here you can add any logic!
                    //1.-Fill DataSet, NonQueries, ExecuteScalar
                    TempDataTable = new DataTable();
    
                    using (SqlConnection SqlConnection = new SqlConnection(ConnectionString))
                    {
                        SqlConnection.Open();
                        using (SqlCommand SqlCommand = new SqlCommand(commandText, SqlConnection))
                        {
                            TempDataTable.Load(SqlCommand.ExecuteReader());
                        }
                    }
                    DataTable = TempDataTable;
                    TempDataTable = null;
                });
            }
            catch (SqlException ex)
            {
                //You can manage you own errors, for example bad queries or bad connections.
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (TempDataTable != null) TempDataTable.Dispose();
            }
    
            return DataTable;
        }
    }
