     private static void DoQuery(object state)
        {
            try
            {
                lock (DbRequestLock)
                {
                    var builder = new SqlConnectionStringBuilder(ConnectionsString)
                        {
                            AsynchronousProcessing = true,
                        };
                    DatabaseRequestsComplete.Reset();
                    _databaseRequestsLeft = BusinessObjects.Count;
                    foreach (var businessObject in BusinessObjects)
                    {
                        var newConnection = new SqlConnection(builder.ConnectionString);
                        newConnection.Open();
                        var command = new SqlCommand(SpName, newConnection) { CommandType = CommandType.StoredProcedure };
                        command.BeginExecuteReader(Callback, new Tuple<SqlCommand, BusinessObject>(command, businessObject),CommandBehavior.CloseConnection);
                    }
                    // need to wait for all to complete                    DatabaseRequestsComplete.WaitOne(10000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Following error occurred while attempting to update objects: " + ex);
            }
        }
        
        private static void Callback(IAsyncResult result)
        {
            var tuple = (Tuple<SqlCommand, BusinessObject>)result.AsyncState;
            var businessObject = tuple.Item2;
            SqlCommand command = tuple.Item1;
            try
            {
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    using (var table = new DataTable(businessObject.Name))
                    {
                        table.Load(reader);
                        businessObject.UpdateData(table);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                // decrement the number of database requests remaining and, if there are 0 fire the mre
                if (Interlocked.Decrement(ref _databaseRequestsLeft) == 0)
                {
                    DatabaseRequestsComplete.Set();
                }
                try
                {
                    command.Dispose();
                    command.Connection.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
 
