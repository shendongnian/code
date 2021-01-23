        public abstract class BaseClass<T> where T: BaseClass<T>, new()
    {
        public int Value { get; private set; } 
        public T CommonWork()
        {
            var result = new T {Value = 1};
            return result;
        }
    }
    public class Derived1 : BaseClass<Derived1>
    {
    }
    public class Derived2 : BaseClass<Derived2>
    {
    }
