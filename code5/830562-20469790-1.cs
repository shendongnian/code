    public class FakeUserRepository : IUserRepository
    {
      public IEnumerable<User> GetAll()
      { 
        return new List<User> { new User {FirstName='Bob', LastName='Smith'}, };
      }
    }
