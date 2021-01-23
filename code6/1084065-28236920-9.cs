    public static Awaiter GetAwaiter(this string s)
    {
        throw new NotImplementedException();
    }
    public abstract class Awaiter : INotifyCompletion
    {
        public abstract bool IsCompleted { get; }
        public abstract void GetResult();
        public abstract void OnCompleted(Action continuation);
    }
