    public interface IGenericRepository<T> where T : class{
    
      Add(Func<T> creator);
      ...
    }
    
    Repository<T> : IGenericRepository<T> where T : class
    {
         public  Add(Func<T> creator) 
         {
            T newOne = creator();
            ....
         }
    }
    // usage
    bookRepository.Add(() => new Book(42, "some title", ...));
 
