    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Transactions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var locker = new SqlApplicationLock("MyAceApplication",
                    "Server=xxx;Database=scratch;User Id=xx;Password=xxx;");
    
                Console.WriteLine("Aquiring the lock");
                using (locker.TakeLock(TimeSpan.FromMinutes(2)))
                {
                    Console.WriteLine("Lock Aquired, doing work which no one else can do. Press any key to release the lock.");
                    Console.ReadKey();
                }
                Console.WriteLine("Lock Released"); 
            }
    
            class SqlApplicationLock : IDisposable
            {
                private readonly String _uniqueId;
                private readonly SqlConnection _sqlConnection;
                private Boolean _isLockTaken = false;
    
                public SqlApplicationLock(
                    String uniqueId,                 
                    String connectionString)
                {
                    _uniqueId = uniqueId;
                    _sqlConnection = new SqlConnection(connectionString);
                    _sqlConnection.Open();
                }
    
                public IDisposable TakeLock(TimeSpan takeLockTimeout)
                {
                    using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Suppress))
                    {
                        SqlCommand sqlCommand = new SqlCommand("sp_getapplock", _sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandTimeout = (int)takeLockTimeout.TotalSeconds;
    
                        sqlCommand.Parameters.AddWithValue("Resource", _uniqueId);
                        sqlCommand.Parameters.AddWithValue("LockOwner", "Session");
                        sqlCommand.Parameters.AddWithValue("LockMode", "Exclusive");
                        sqlCommand.Parameters.AddWithValue("LockTimeout", (Int32)takeLockTimeout.TotalMilliseconds);
    
                        SqlParameter returnValue = sqlCommand.Parameters.Add("ReturnValue", SqlDbType.Int);
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        sqlCommand.ExecuteNonQuery();
    
                        if ((int)returnValue.Value < 0)
                        {
                            throw new Exception(String.Format("sp_getapplock failed with errorCode '{0}'",
                                returnValue.Value));
                        }
    
                        _isLockTaken = true;
    
                        transactionScope.Complete();
                    }
    
                    return this;
                }
    
                public void ReleaseLock()
                {
                    using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Suppress))
                    {
                        SqlCommand sqlCommand = new SqlCommand("sp_releaseapplock", _sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
    
                        sqlCommand.Parameters.AddWithValue("Resource", _uniqueId);
                        sqlCommand.Parameters.AddWithValue("LockOwner", "Session");
    
                        sqlCommand.ExecuteNonQuery();
                        _isLockTaken = false;
                        transactionScope.Complete();
                    }
                }
    
                public void Dispose()
                {
                    if (_isLockTaken)
                    {
                        ReleaseLock();
                    }
                    _sqlConnection.Close();
                }
            }
        }
    }
