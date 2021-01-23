        public interface IRepository<T> where T : class, IEntity
        {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        void Attach(T item);
        IQueryable<T> All<TProperty>(params Expression<Func<T, TProperty>>[] path);
        IQueryable<T> All(params string[] path);
        T Find(object id);
        T First(Expression<Func<T, bool>> predicate, params string[] path);
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate, params string[] path);
        T First<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] path);
        IQueryable<T> Where<TProperty>(Expression<Func<T, bool>> predicate, params Expression<Func<T, TProperty>>[] path);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, params string[] includes);
       }
