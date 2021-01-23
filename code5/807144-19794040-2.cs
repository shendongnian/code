        public async Task DoSomething()
        {
            Console.WriteLine("Begin");
            int i = await DoSomethingElse();
            Console.WriteLine("End " + i);
        }
        public Task<int> DoSomethingElse()
        {
            return new Task<int>(() =>
            {
                // do heavy work
                Thread.Sleep(1000);
                return 1;
            });
        }
