    public abstract class BaseClass
    {
        public abstract IEnumerable Data { get; }
    }
    public class ChildClass<T> : BaseClass
    {
        public List<T> SomeList { get; set; }
        public IEnumerable Data { get { return SomeList; } }
    }
