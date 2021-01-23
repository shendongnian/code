    public class ResourceStore<T> : IResourceStore where T : Resource 
    { 
             private List<T> _store;
    
        public IEnumerable<T> Store { get { return _store; } } 
    
        public void AddResource(T resource)
        {
            _store = new List<T>();
            _store.Add(resource);
        }
        void IResourceStore.AddResource(Resource resource)
        {
            //possible excepion here for type mismach!
            AddResource(resource as T);
        }
    }
