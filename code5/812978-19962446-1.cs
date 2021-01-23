    private sealed class MyFactory : IMyFactory
    {
        private readonly Container container;
        public MyFactory(Container container)
        {
            this.container = container;
        }
        public IMyWorker CreateInstance(WorkerType workerType)
        {
            if (workerType == WorkerType.A)
                  return this.container.GetInstance<IWorkerA>();
            return this.container.GetInstance<IWorkerB>();
        }
    }
