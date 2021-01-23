    public class CustomerRepository : IBaseRepository
    {
      public T Get <T>(int id) 
      {
        // load data from DB
        return new Customer();
      }
    }
