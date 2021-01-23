    public class SpecialCollection<TKey, TValue> : Dictionary<TKey, TValue>
        where TKey : CompositKey
    {
    }
    public abstract class CompositeKey
    {
        protected CompositeKey(object id, object name)
        {
            Id = id;
            Name = name;
        }
        public object Id { get; private set; }
        public object Name { get; private set; }
    }
    public class CompositeKey<TId, TName> : CompositeKey
    {
        public CompositeKey(TId id, TName name)
            : base(id, name) { }
        public new TId Id
        {
            get { return (TId)base.Id; }
        }
        public new TName Name
        {
            get { return (TName)base.Name; }
        }
    }
