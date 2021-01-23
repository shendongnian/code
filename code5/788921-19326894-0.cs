    public interface IEntity
    {
    }
    public interface IRepository
    {
        ISession Session { get; }
    }
    public class DataObjectBase<T> where T : IEntity
    {
        private IRepository Repository { get; set; }
        public DataObjectBase(IRepository repository)
        {
            this.Repository = repository;
        }
        public T Get(int id)
        {
            return Repository.Session.Get<T>(id);
        }
        public void Save(T value)
        {
            Repository.Session.Save(value);
        }
        public void Update(T value)
        {
            Repository.Session.Update(value);
        }
        public void Delete(T value)
        {
            Repository.Session.Delete(value);
        }
        public IQueryable<T> Query()
        {
            return Repository.Session.Query<T>();
        }
    }
