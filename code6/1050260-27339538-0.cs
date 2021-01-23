        public interface IDataRepository<T>
        {
            IQueryable<T> Get();
            T Get(int id);
            T Add(T obj);
            T Update(T obj);
            void Delete(T obj);
        }
