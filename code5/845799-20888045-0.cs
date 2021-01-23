        [Fact]
        public void Test()
        {
            var result = new ConcurrentBag<int>(); //result
            var tasks = new List<Task>();
            Enumerable.Range(0, 5).ToList() //- it's equivalent how many threads
                      .ForEach(x => tasks.Add(Task.Run(() => result.Add(DoWork(x)))));
            Task.WaitAll(tasks.ToArray()); //- Join threads
            result.ToList().ForEach(Console.WriteLine);
        }
        private int DoWork(int taskId)
        {
            return taskId;
        }
