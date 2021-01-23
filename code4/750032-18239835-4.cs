    public class MyEqualityComparer<T> : IEqualityComparer<T>
    {
        Func<T, T, bool> _equalsFunction;
        Func<T, int> _hashCodeFunction;
        public MyEqualityComparer(
            Func<T, T, bool> equalsFunction, Func<T, int> hashCodeFunction)
        {
            if (equalsFunction == null) throw new ArgumentNullException();
            if (hashCodeFunction == null) throw new ArgumentNullException();
            _equalsFunction = equalsFunction;
            _hashCodeFunction = hashCodeFunction;
        }
        public bool Equals(T x, T y)
        {
            return _equalsFunction(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _hashCodeFunction(obj);
        }
    }
