    public interface IThing
    {
        object Value { get; }
    }
    public interface IThing<T> : IThing
    {
        T Value { get; }
    }
    public class Thing<T> : IThing<T>
    {
        private T t;
        public object Value
        {
            get
            {
                return this.Get();
            }
        }
        public T Value<T>()
        {
            get
            {
                return this.t;
            }
        }
    }
