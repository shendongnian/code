    public interface IDataArgs<out T>
    {
        T Data { get; }
    }
    public class DataEventArgs<T> : EventArgs, IDataArgs<T>
    {
        public DataEventArgs<T>(T data) 
        {
            _data = data;
        }
        private T _data;
        public T Data { get { return _data; } }
    }
