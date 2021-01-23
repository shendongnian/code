    public class TplTaskFactory : ITaskFactory
    {
        public Task StartNew(Action action)
        {
            return Task.Factory.StartNew(action);
        }
    }
