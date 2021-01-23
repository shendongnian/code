    [TestMethod]
    public async Task RunTest_2()
    {
        var result = await GetStringAsyncWithoutAwait();
        Console.WriteLine(result);
    }
    public Task<string> GetStringAsyncWithoutAwait()
    {
        // Code before first await
        var builder = new StringBuilder();
        var secondLine = "Second Line";
        return new StateMachine(this, builder, secondLine).CreateTask();
    }
    private class StateMachine
    {
        private readonly AsyncTest instance;
        private readonly StringBuilder builder;
        private readonly string secondLine;
        private readonly TaskCompletionSource<string> completionSource;
        private int state = 0;
        public StateMachine(AsyncTest instance, StringBuilder builder, string secondLine)
        {
            this.instance = instance;
            this.builder = builder;
            this.secondLine = secondLine;
            this.completionSource = new TaskCompletionSource<string>();
        }
        public Task<string> CreateTask()
        {
            DoWork();
            return this.completionSource.Task;
        }
        private void DoWork()
        {
            switch (this.state)
            {
                case 0:
                    goto state_0;
                case 1:
                    goto state_1;
                case 2:
                    goto state_2;
            }
            state_0:
                this.state = 1;
                // First await
                var firstAwaiter = this.instance.AppendLineAsync(builder, "First Line")
                                            .GetAwaiter();
                firstAwaiter.OnCompleted(DoWork);
                return;
            state_1:
                this.state = 2;
                // Inner synchronous code
                this.builder.AppendLine(this.secondLine);
                // Second await
                var secondAwaiter = this.instance.AppendLineAsync(builder, "Third Line")
                                                .GetAwaiter();
                secondAwaiter.OnCompleted(DoWork);
                return;
            state_2:
                // Return
                var result = this.builder.ToString();
                this.completionSource.SetResult(result);
        }
    }
