        public class Container<T>
        {
            public Container(T value)
            {
                Value = value;
            }
            public T Value { get; private set; }
        }
        public void Bar<T>(T item)
        {
            this.Foo<Container<T>>(new Container<T>(item));
        } 
