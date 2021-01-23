    namespace ConsoleApplication1
    {
        class Program
        {
            private static string DataIP;        
            private static string Database;          
            private static string IntanceID;
            static void Main(string[] args)
            {
                DataIP = @"FREDOU-PC\SQLEXPRESS";  Database = "testing"; IntanceID = "123";
                int count = 0;
                System.Diagnostics.Stopwatch swWholeThing = System.Diagnostics.Stopwatch.StartNew();
                System.Diagnostics.Stopwatch swFormat = new System.Diagnostics.Stopwatch();
                System.Diagnostics.Stopwatch swOpen = new System.Diagnostics.Stopwatch();
                System.Diagnostics.Stopwatch swExecute = new System.Diagnostics.Stopwatch();
                for (int i = 0; i < 100000; ++i)
                {
                    using (System.Data.SqlClient.SqlConnection sqlconn = new System.Data.SqlClient.SqlConnection(SqlConnectionString(ref swFormat)))
                    {
                       using (System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand("dbo.counttable1", sqlconn))
                       {
                           sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                           sqlcmd.Parameters.Clear();
                           swOpen.Start();
                           sqlconn.Open();
                           swOpen.Stop();
                           swExecute.Start();
                           using (System.Data.SqlClient.SqlDataReader sqlDR = sqlcmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                           {
                               if (sqlDR.Read())
                                count += sqlDR.GetInt32(0);
                           }
                           swExecute.Stop();
                        }
                    }                
                }
                swWholeThing.Stop();
                System.Console.WriteLine("swFormat: " + swFormat.ElapsedMilliseconds);
                System.Console.WriteLine("swOpen: " + swOpen.ElapsedMilliseconds);
                System.Console.WriteLine("swExecute: " + swExecute.ElapsedMilliseconds);
                System.Console.WriteLine("swWholeThing: " + swWholeThing.ElapsedMilliseconds + " " + count);
                System.Console.ReadKey();
            }
            public static string SqlConnectionString(ref System.Diagnostics.Stopwatch swFormat)
            {
                swFormat.Start();
                var str =  string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;Application Name={2};Asynchronous Processing=true;MultipleActiveResultSets=true;Max Pool Size=524;Pooling=true;",
                            DataIP,  Database, IntanceID);
                swFormat.Stop();
                return str;
            }
        }
    }
