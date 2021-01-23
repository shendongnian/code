    public class Vector<T>
    {
        public Vector(double value, T tail)
        {
            Value = value;
            Tail = tail;
        }
        public double Value { get; private set; }
        private T Tail { get; private set; }
        public Vector<Vector<T>> Add(double value)
        {
            return new Vector<Vector<T>>(value, this);
        }
    }
    public class Vector
    {
        public static readonly Vector<Void> Empty = new Vector<Void>(0, new Void());
    }
