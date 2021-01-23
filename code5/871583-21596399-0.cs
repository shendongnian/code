    public interface IMultiplyable<T>
    {
        T Multiply(T x);
    }
    public class Int : IMultiplyable<Int>
    {
        private int _data { get; set; }
        public Int(int data)
        {
            _data = data;
        }
        public Int Multiply(Int x)
        {
            return new Int(_data * x._data);
        }
        public override string ToString()
        {
            return _data.ToString();
        }
    }
    public class GenericItem<T> where T : IMultiplyable<T>
    {
        private T data;
        private T counter;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public GenericItem() { }
        public GenericItem(T _data)
        {
            data = _data;
        }
        public T returnCounterMultiply(T value)
        {
            return Data.Multiply(value);
        }
        public override string ToString()
        {
            return Data.ToString();
        }
    }
