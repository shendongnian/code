    public abstract class NamedObject
    {
        public string Name { get; set; }
    }
    public class ComponentCollection<T> where T : NamedObject
    {
        private readonly List<T> _components = new List<T>();
        public T this[string name]
        {
            get { return Get(name); }
        }
        public T Get(string name)
        {
            return _components.Single(x => x.Name == name);
        }
        public void Add(T component)
        {
            _components.Add(component);
        }
        public void Remove(string name)
        {
            _components.RemoveAll(x => x.Name == name);
        }
    }
