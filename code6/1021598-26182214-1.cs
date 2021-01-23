    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
    }
    public interface IPostRepository : IRepository<int>
    {
        int GetComentCount();
    }
    public class EFRepository<T> : IRepository<T>
    {
        public void Add(T entity) { Console.WriteLine("Works"); }
        public void Update(T entity) { /*implementation...*/ }
        public void Delete(T entity) { /*implementation...*/ }
        public IList<T> GetAll() { return null; }
    }
    public class PostRepository : EFRepository<int>, IPostRepository
    {
        public int GetComentCount() { return 0; }
    }
    public interface IUnitOfWork
    {
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IPostRepository PostRepository { get { return new PostRepository(); } }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
