    public class UserRepository<User> : IRepository<User>
    { 
        protected Table<User> DataTable;
 
        public Repository(DataContext dataContext)
        {
            DataTable = dataContext.GetTable<User>();
        }
 
        #region IRepository<T> Members
 
        public void Insert(User entity)
        {
            DataTable.InsertOnSubmit(entity);
        }
 
        public void Delete(User entity)
        {
            DataTable.DeleteOnSubmit(entity);
        }
 
        public IQueryable<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            return DataTable.Where(predicate);
        }
 
        public IQueryable<User> GetAll()
        {
            return DataTable;
        }
 
        public User GetById(int id)
        {
            // Sidenote: the == operator throws NotSupported Exception!
            // 'The Mapping of Interface Member is not supported'
            // Use .Equals() instead
            return DataTable.Single(e => e.Id.Equals(id));
        }
 
        #endregion
    }
