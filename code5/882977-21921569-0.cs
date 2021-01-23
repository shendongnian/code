    public class SomeClass
    {
        public async Task Fun()
        {
            // execute both service requests at the same time
            Task<Result> fooTask = ServiceCallAsync1();
            Task<Result> barTask = ServiceCallAsync2();
            // wait for both of them to be complete.
            Result[] t = await Task.WhenAll(new[] { fooTask, barTask });
            AssignDefaultValues();
        }
        public Task<Result> ServiceCallAsync1()
        {
            TaskCompletionSource<Result> completion = new TaskCompletionSource<Result>();
            serviceclient.DoSomething(() =>
            {
                completion.SetResult(new FooResult());
            });
            return completion.Task;
        }
        public Task<Result> ServiceCallAsync2()
        {
            TaskCompletionSource<Result> completion = new TaskCompletionSource<Result>();
            serviceclient.DoSomething(() =>
            {
                completion.SetResult(new BarResult());
            });
            return completion.Task;
        }
        private void AssignDefaultValues()
        {
        }
    }
