    public class DeepCopyArrayOfValueTypes<T> : IDeepCopyable<T[]>
        where T : struct
    {
        public T[] DeepCopy(T[] t) {...}
    }
