    public class GenericClass<T> : BaseClass where T: struct
    {
        public T data;
        public GenericClass(T value)
        {
            data = value;
        }
        public T DoSomething()
        {
            return (T)(data * (dynamic)0.826f);
        }
        public override string DoSomethingToString()
        {
            return DoSomething().ToString();
        }
    }
