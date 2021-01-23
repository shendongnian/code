    interface IFoo
    {
        Task<Bar> CreateBarAsync(CancellationToken token);
    }
    class Foo2 : IFoo
    {
        public Task<Bar> CreateBarAsync(CancellationToken token)
        {
            var task = new Task<Bar>(() => SynchronousBarCreator(), token);
            task.RunSynchronously();
            return task;
        }
    }
