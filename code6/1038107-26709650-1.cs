    public class LockWrapper<T>
    {
        public T InsideClass { get; set; }
        public readonly object _lock;
    }
