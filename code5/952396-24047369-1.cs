    public class MyClass<T>
    {
        private BlockingCollection<T> workQueue = new BlockingCollection<T>();
        public MyClass()
        {
            Task.Factory.StartNew(ProcessWorkQueue, TaskCreationOptions.LongRunning);
        }
        public void DoWork(List<T> work)
        {
            foreach (var workItem in work)
            {
                workQueue.Add(workItem);
            }
        }
        public void StopWork()
        {
            workQueue.CompleteAdding();
        }
        public void ProcessWorkQueue()
        {
            foreach(var item in workQueue.GetConsumingEnumerable())
            {
                //Do something here
            }
        }
    }
