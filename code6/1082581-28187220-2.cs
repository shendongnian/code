    class Program
    {
        static void Main(string[] args)
        {
            var mpo = new MyPersistedObject();
            var ptp = mpo.Definition.PropertiesToPersist;
        }
    }
    public class PersistedElementDefinition<T> where T : IPersistedObject
    {
        private readonly List<PersistedPropertyDefinition<T>> _propsToPersist = new List<PersistedPropertyDefinition<T>>();
        public List<PersistedPropertyDefinition<T>> PropertiesToPersist
        {
            get { return _propsToPersist; }
        }
    }
    public class PersistedPropertyDefinition<T> where T : IPersistedObject
    {
        public Func<T, object> PropertyGetter { get; set; }
        public Action<T, object> PropertySetter { get; set; }
    }
    public interface IPersistedObject
    {
        dynamic Definition { get; }
    }
    public class MyPersistedObject : IPersistedObject
    {
        private readonly PersistedElementDefinition<MyPersistedObject> _definition = new PersistedElementDefinition<MyPersistedObject>();
        public dynamic Definition { get { return _definition; } }
    }
