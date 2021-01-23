        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(InitializeMethod1());
            tasks.Add(InitializeMethod2());
            Task.WaitAll(tasks.ToArray());
        }
        public static async Task InitializeMethod1()
        {
        }
        public static async Task InitializeMethod2()
        {
        }
