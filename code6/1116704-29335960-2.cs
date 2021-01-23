    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Synchronization.Data;
    using Microsoft.Synchronization.Data.SqlServer;
    using Microsoft.Synchronization;
    namespace StackOverflow_SyncFramework
    {
        public class _CSyncDetails
        {
            public int UploadChangesTotal;
            public DateTime SyncStartTime;
            public int DownloadChangesTotal;
            public DateTime SyncEndTime;
        }
        public class Program
        {
            static void Main(string[] args)
            {
                _cSynchronization sync = new _cSynchronization();
                sync._MSync();
                Console.ReadLine();
            }
        }
        public class _cSynchronization
        {
            public static int transactionCount;
            public static uint BatchSize = 10000;
            public static uint MemorySize = 20000;
            public const string ServerConnString = 
                @"Data Source=.\SQLExpress;initial catalog=SyncTestServer;integrated security=True;MultipleActiveResultSets=True;";
            public const string ClientConnString = 
                @"Data Source=.\SQLExpress;initial catalog=SyncTestClient;integrated security=True;MultipleActiveResultSets=True;";
            public static List<string> _MGetAllTableList()
            {
                // I just created two databases that each have the following table
                // Synchronization is working
                List<string> list = new List<string>()
                {
                    "Table1",
                    "Table2"
                };
                return list;
            }
            public static void SetUp(string _pTableName)
            {
                // Connection to  SQL Server database
                SqlConnection serverConn =
                    new SqlConnection(ServerConnString);
                // Connection to SQL client database
                SqlConnection clientConn =
                    new SqlConnection(ClientConnString);
                // Create a scope named "product" and add tables to it.
                Console.WriteLine(_pTableName);
                DbSyncScopeDescription productScope = new DbSyncScopeDescription(_pTableName + "_SCOP");
                // Define the Products table.
                DbSyncTableDescription productDescription =
                                                        SqlSyncDescriptionBuilder.GetDescriptionForTable(_pTableName, serverConn);
                // Add the Table to the scope object.    
                productScope.Tables.Add(productDescription);
                // Create a provisioning object for "product" and apply it to the on-premise database if one does not exist.
                SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, productScope);
                serverProvision.ObjectSchema = ".dbo";
                serverProvision.SetCreateProceduresForAdditionalScopeDefault(DbSyncCreationOption.Create);
                serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
                serverProvision.SetCreateProceduresDefault(DbSyncCreationOption.CreateOrUseExisting);
                serverProvision.SetCreateTrackingTableDefault(DbSyncCreationOption.CreateOrUseExisting);
                serverProvision.SetCreateTriggersDefault(DbSyncCreationOption.CreateOrUseExisting);
                if (!serverProvision.ScopeExists(_pTableName + "_SCOP"))
                    serverProvision.Apply();
                // Provision the SQL client database from the on-premise SQL Server database if one does not exist.
                SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, productScope);
                if (!clientProvision.ScopeExists(_pTableName + "_SCOP"))
                    clientProvision.Apply();
                // Shut down database connections.
                serverConn.Close();
                serverConn.Dispose();
                clientConn.Close();
                clientConn.Dispose();
            }
            public static List<_CSyncDetails> Synchronize(string _pScopeName, SyncDirectionOrder _pDirection)
            {
                // Connection to  SQL Server database
                SqlConnection serverConn = 
                    new SqlConnection(ServerConnString);
                // Connection to SQL client database
                SqlConnection clientConn =
                    new SqlConnection(ClientConnString);
                List<_CSyncDetails> _Statics = new List<_CSyncDetails>();
                // Perform Synchronization between SQL Server and the SQL client.
                SyncOrchestrator syncOrchestrator = new SyncOrchestrator();
                // Create provider for SQL Server
                SqlSyncProvider serverProvider = new SqlSyncProvider(_pScopeName, serverConn);
                // Set the command timeout and maximum transaction size for the SQL Azure provider.
                SqlSyncProvider clientProvider = new SqlSyncProvider(_pScopeName, clientConn);
                clientProvider.CommandTimeout = serverProvider.CommandTimeout = 500;
                //Set memory allocation to the database providers
                clientProvider.MemoryDataCacheSize = serverProvider.MemoryDataCacheSize = MemorySize;
                //Set application transaction size on destination provider.
                serverProvider.ApplicationTransactionSize = BatchSize;
                //Count transactions
                serverProvider.ChangesApplied += 
                    new EventHandler<DbChangesAppliedEventArgs>(RemoteProvider_ChangesApplied);
                // Set Local provider of SyncOrchestrator to the server provider
                syncOrchestrator.LocalProvider = serverProvider;
                // Set Remote provider of SyncOrchestrator to the client provider
                syncOrchestrator.RemoteProvider = clientProvider;
                // Set the direction of SyncOrchestrator session to Upload and Download
                syncOrchestrator.Direction = _pDirection;
                // Create SyncOperations Statistics Object
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
                _Statics.Add(new _CSyncDetails
                {
                    UploadChangesTotal = syncStats.UploadChangesTotal,
                    SyncStartTime = syncStats.SyncStartTime,
                    DownloadChangesTotal = syncStats.DownloadChangesTotal,
                    SyncEndTime = syncStats.SyncEndTime
                });
                // Shut down database connections.
                serverConn.Close();
                serverConn.Dispose();
                clientConn.Close();
                clientConn.Dispose();
                return _Statics;
            }
            private static void RemoteProvider_ChangesApplied(object sender, DbChangesAppliedEventArgs e)
            {
                Console.WriteLine("Changes Applied");
            }
            public void _MSync()
            {
                // Define the Products table.
                List<string> _Tablelist = new List<string>();
                _Tablelist.AddRange(_cSynchronization._MGetAllTableList());
                foreach (string tbl in _Tablelist)
                {
                    _cSynchronization.Synchronize(tbl + "_SCOP", SyncDirectionOrder.DownloadAndUpload);
                }
            }
        }
    }
