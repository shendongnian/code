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
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                Data = (T)conv.ConvertFromString("42");
            }
        }
    }
