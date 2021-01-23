    public class Foo<T>
    {
    
        public T Data
        {
            get;
            protected set;
        }
    
        public Foo()
        {
            if (Data is int)
                Data = (T)(object)42;
        }
    }
