    public interface IResourceStore<T> where T : Resource
    {
        void AddResource(T resource);
    }
    public class ResourceStore<T> : IResourceStore<T> where T : Resource
    {
        private List<T> _store = new List<T>();
    
        public IEnumerable<T> Store { get { return _store; } } 
    
        public void AddResource(T resource)
        {
            //_store = new List<T>(); //really?
            _store.Add(resource);
        }
    }
