    CancellationTokenSource cancelSource = new CancellationTokenSource();
    System.Threading.Timer timer = new System.Threading.Timer(callback =>
    {
        //start sync
        Task syncTask = Task.Factory.StartNew(syncAction =>
            {
                using (SqlConnection conn = 
                    new SqlConnection(
                       ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand syncCommand = new SqlCommand
                    {
                        CommandText = "SELECT getdate() \n WAITFOR DELAY '00:11'; ",
                        CommandTimeout = 600,
                        Transaction = conn.BeginTransaction(),
                        Connection = conn
                    })
                    {
                        try
                        {
                            IAsyncResult t = syncCommand.BeginExecuteNonQuery();
                            SpinWait.SpinUntil(() => 
                                (t.IsCompleted || cancelSource.Token.IsCancellationRequested));
                            if (cancelSource.Token.IsCancellationRequested && !t.IsCompleted)
                                syncCommand.Transaction.Rollback();
    
                        }
                        catch (TimeoutException timeoutException)
                        {
                            syncCommand.Transaction.Rollback();
                            //log a failed sync attepmt here
                            Console.WriteLine(timeoutException.ToString());
                        }
                        finally
                        {
                            syncCommand.Connection.Close();
                        }
                    }
                }
            }, null, cancelSource.Token);
        //set up a timer for processing in the interim, save some time for rollback
        System.Threading.Timer spinTimer = new System.Threading.Timer(c => {
            cancelSource.Cancel();
        }, null, TimeSpan.FromMinutes(9), TimeSpan.FromSeconds(5)); 
    
        //spin here until the spintimer elapses;
        //this is optional, but would be useful for debugging.
        SpinWait.SpinUntil(()=>(syncTask.IsCompleted || cancelSource.Token.IsCancellationRequested));
    
    }, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(10));
