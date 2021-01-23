    public class ResourceStore<T> : IResourceStore<T> where T : Resource
    {
        private List<T> _store;
        public IEnumerable<T> Store { get { return _store; } }
        public void AddResource(T resource)
        {
            _store = new List<T> {resource};
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Store.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public interface IResourceStore<T> : IEnumerable<T>
       where T : Resource
    {
            void AddResource(T resource);
    }
    public abstract class Resource
    {
        public int Count { get; set; }
        protected Resource(int resourceCount)
        {
            Count = resourceCount;
        }
    }
