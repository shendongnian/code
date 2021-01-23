    public interface IVector
    {
        double Value { get; }
        IVector Tail { get; }
    }
    public class Vector<T> : IVector
        where T : IVector
    {
        internal Vector(double value, T tail)
        {
            Value = value;
            Tail = tail;
        }
        public double Value { get; private set; }
        public T Tail { get; private set; }
        public Vector<Vector<T>> Add(double value)
        {
            return new Vector<Vector<T>>(value, this);
        }
    }
    internal class EmptyVector : IVector
    {
        public double Value
        {
            get { throw new NotImplementedException(); }
        }
        public IVector Tail
        {
            get { return null; }
        }
    }
    public static class Vector
    {
        public static readonly Vector<IVector> Empty = new Vector<IVector>(
            0, new EmptyVector());
        public static IEnumerable<double> AllValues(this IVector vector)
        {
            IVector current = vector;
            while (current != Vector.Empty && current != null)
            {
                yield return current.Value;
                current = current.Tail;
            };
        }
    }
