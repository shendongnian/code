    namespace ConsoleApplication1
    {
        class Program
        {
            private static string DataIP;        private static string port;
            private static string Database;        private static string username;
            private static string password;        private static string IntanceID;
            static void Main(string[] args)
            {
                DataIP = "123"; port = "123"; Database = "123"; username = "123"; password = "123"; IntanceID = "123";
                int count = 0;
                var sw = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < 1000000; ++i)
                    count += SqlConnectionString().Length;
                sw.Stop();
                System.Console.WriteLine(sw.ElapsedMilliseconds + " " + count);
                System.Console.ReadKey();
            }
            public static string SqlConnectionString()
            {
                return string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4};Application Name={5};Asynchronous Processing=true;MultipleActiveResultSets=true;Max Pool Size=524;Pooling=true;",
                            DataIP, port, Database, username, password, IntanceID);
            }
        }
    }
