    public class Foo<T>
    {
        private T item;
        public Foo()
        {
            var type = typeof(T);
            if (Nullable.GetUnderlyingType(type) != null)
                return;
            if (type.IsClass)
                return;
            throw new InvalidOperationException("Type is not nullable or reference type.");
        }
        public bool IsNull()
        {
            return item == null;
        }
    }
