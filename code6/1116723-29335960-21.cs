    public class Program
    {
        public static string[] ClientConnString = new string[] 
            {
                @"Data Source=.\SQLExpress;initial catalog=SyncTestClient01;integrated security=True;MultipleActiveResultSets=True;"
                ,@"Data Source=.\SQLExpress;initial catalog=SyncTestClient02;integrated security=True;MultipleActiveResultSets=True;"
                ,@"Data Source=.\SQLExpress;initial catalog=SyncTestClient03;integrated security=True;MultipleActiveResultSets=True;"
            };
    
        static void Main(string[] args)
        {
            foreach (var connString in ClientConnString)
            {
                Action action = () =>
                {
                    _cSynchronization sync = new _cSynchronization();
                    sync._MSync(connString);
                };
                Task.Factory.StartNew(action);
            }
    
            Console.ReadLine();
        }
    }
