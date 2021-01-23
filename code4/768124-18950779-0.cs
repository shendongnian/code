    class DatabaseUpdater
    {
        private readonly Timer _timer;
        private List<Thread> _threads;
        private readonly List<DatabaseConfig> _dbConfigs;
        public DatabaseUpdater(int seconds, List<DatabaseConfig> dbConfigs)
        {
            _timer = new Timer(seconds * 1000);
            _timer.Elapsed += TimerElapsed;
            _dbConfigs = dbConfigs;
        }
        public void Start()
        {
            StartThreads();
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
            StopThreads();
        }
        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            StopThreads();
            StartThreads();
        }
        private void StartThreads()
        {
            var newThreads = new List<Thread>();
            foreach (var config in _dbConfigs)
            {
                var thread = new Thread(DoWork);
                thread.Start(config);
                newThreads.Add(thread);
            }
            _threads = newThreads;
        }
        private void StopThreads()
        {
            if (_threads == null) return;
            var oldThreads = _threads;
            foreach (var thread in oldThreads)
            {
                thread.Abort();
            }
        }
        static void DoWork(object objConfig)
        {
            var dbConfig = objConfig as DatabaseConfig;
            if (null == dbConfig) return;
            var n = GetRandomNumber();
            try
            {
                ConsoleWriteLine("Sync started for : {0} - {1} sec work.", dbConfig.Id, n);
                // update/sync db
                Thread.Sleep(1000 * n);
                ConsoleWriteLine("Sync finished for : {0} - {1} sec work.", dbConfig.Id, n);
            }
            catch (Exception ex)
            {
                // cancel/rollback db transaction
                ConsoleWriteLine("Sync cancelled for : {0} - {1} sec work.",
                    dbConfig.Id, n);
            }
        }
        static readonly Random Random = new Random();
        [MethodImpl(MethodImplOptions.Synchronized)]
        static int GetRandomNumber()
        {
            return Random.Next(5, 20);
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        static void ConsoleWriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }
    }
    static void Main(string[] args)
    {
        var configs = new List<DatabaseConfig>();
        for (var i = 1; i <= 3; i++)
        {
            configs.Add(new DatabaseConfig() { Id = i });
        }
        var databaseUpdater = new DatabaseUpdater(10, configs);
        databaseUpdater.Start();
        Console.ReadKey();
        databaseUpdater.Stop();
    }
