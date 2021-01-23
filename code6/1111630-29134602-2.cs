    public interface IScheduler
    {
        void Execute(Action action);
    }
    // Injected when not under test
    public class ThreadPoolScheduler : IScheduler
    {
        public void Execute(Action action)
        {
            Task.Run(action);
        }
    }
    // Used for testing
    public class ImmediateScheduler : IScheduler
    {
        public void Execute(Action action)
        {
            action();
        }
    }
