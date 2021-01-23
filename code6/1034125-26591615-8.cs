    namespace SchoolDemo.Repository.Interface
    {
        public interface IReadOneRepository<TEntity>
        {
            TEntity Read(int id);
        }
    }
