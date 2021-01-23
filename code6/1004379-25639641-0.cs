    using StackExchange.Profiling;
    using StackExchange.Profiling.Storage;
    using System;
    using System.Threading;
    //using StackExchange.Profiling.Helpers.Dapper; // only for table creation
    //using System.Data.SqlClient; // only for table creation
    
    static class Program
    {
        static void Main()
        {
            const string ConnectionString = "Initial Catalog=MiniProf;Data Source=.;Integrated Security=true;";
    
            //using(var conn = new SqlConnection(ConnectionString))
            //{
            //    conn.Open();
            //    conn.Execute(SqlServerStorage.TableCreationScript);
            //}
            MiniProfiler.Settings.Storage = new SqlServerStorage(ConnectionString);
            MiniProfiler.Settings.ProfilerProvider = new SingletonProfilerProvider();
            MiniProfiler.Settings.ProfilerProvider.Start(ProfileLevel.Info);
            DoStuff();
            MiniProfiler.Settings.ProfilerProvider.Stop(false);
    
            MiniProfiler.Settings.Storage.Save(MiniProfiler.Current);
        }
        static void DoStuff()
        {
            using (MiniProfiler.Current.Step("DoStuff"))
            {
                for (int i = 0; i < 5; i++)
                {
                    using (MiniProfiler.Current.Step("Loop iteration"))
                    {
                        Thread.Sleep(200);
                        Console.Write(".");
                    }
                }
            }
            Console.WriteLine();
        }
    }
