     public interface IMyClassRepository : IDisposable
      {
        IQueryable<MyClass> All { get; }
        IQueryable<MyClass> AllIncluding(params Expression<Func<MyClass, object>>[] includeProperties);
        MyClass Find(int id);
        void InsertOrUpdate(MyClass myClass);
        void Delete(int id);
        void Save();
      }
    
      public class MyClassRepository : IMyClassRepository
      {
        DBContext context = new DBContext();
        public IQueryable<MyClass> All
        {
          get { return context.Employees; }
        }
        public IQueryable<MyClass> AllIncluding(params Expression<Func<MyClass, object>>[] includeProperties)
        {
          IQueryable<MyClass> query = context.MyClasses;
          foreach (var includeProperty in includeProperties)
          {
            query = query.Include(includeProperty);
          }
          return query;
        }
        public MyClass Find(int id)
        {
          return context.MyClasses.Find(id);
        }
        public void InsertOrUpdate(MyClass myClass)
        {
          if (myClass.Id == default(int))
          {
            // New entity
            context.MyClasses.Add(myClass);
          }
          else
          {
            // Existing entity
            context.Entry(myClass).State = EntityState.Modified;
          }
        }
        public void Delete(int id)
        {
          var employee = context.Employees.Find(id);
          context.Employees.Remove(employee);
        }
        public void Save()
        {
          context.SaveChanges();
        }
        public void Dispose()
        {
          context.Dispose();
        }
      }
    
      public class MyClass
      {
      }
