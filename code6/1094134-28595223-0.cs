    // repository 
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
    }
    // repository impl
    public class SimpleRepository : IRepository<string>
    {
        private readonly IList<string> _items = new List<string>();
        
        public SimpleRepository()
        {}
        public Task<IEnumerable<string>> GetAll()
        {
            if (_items.Count > 10)
                _items.Clear();
            _items.Add(string.Format("string{0}", _items.Count));
            
            Thread.Sleep(250); // queries take some time...
            return Task.FromResult((IEnumerable<string>) _items);
        }
    }
