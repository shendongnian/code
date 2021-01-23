        [Fact]
        public void Test()
        {
            List<Task<int>> tasks = Enumerable.Range(0, 5) //- it's equivalent how many threads
                                              .Select(x => Task.Run(() => DoWork(x)))
                                              .ToList();
            int[] result = Task.WhenAll(tasks).Result; //- Join threads
            result.ToList().ForEach(Console.WriteLine);
        }
        private int DoWork(int taskId)
        {
            return taskId;
        }
