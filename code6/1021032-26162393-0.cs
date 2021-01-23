    public abstract class BinaryNodeAbstract<T, L> where L : BinaryNodeAbstract<T, L>
    {
        public T Value;
        public L Left;
        public L Right;
    }
