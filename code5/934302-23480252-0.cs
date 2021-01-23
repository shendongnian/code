    public interface IWrapper<out T>
    {
        T Value { get; }
    }
    public class Wrapper<T> : IWrapper<T>
    {
        public Wrapper(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
    }
