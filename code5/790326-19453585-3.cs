    public interface VariantVisitor<T, U>
    {
        void Visit(T item);
        void Visit(U item);
    }
    public class Variant<T, U>
    {
        public T Item1 { get; private set; }
        private bool _item1Set;
        public U Item2 { get; private set; }
        private bool _item2Set;
        public Variant()
        {
        }
        public void Set(T item)
        {
            this.Item1 = item;
            _item1Set = true;
            _item2Set = false;
        }
        public void Set(U item)
        {
            this.Item2 = item;
            _item1Set = false;
            _item2Set = true;
        }
        public void ApplyVisitor(VariantVisitor<T, U> visitor)
        {
            if (_item1Set)
            {
                visitor.Visit(this.Item1);
            }
            else if (_item2Set)
            {
                visitor.Visit(this.Item2);
            }
            else
            {
                throw new InvalidOperationException("Variant not set");
            }
        }
    }
