The EF data context will have a constructor overload with the nameOrConnectionString parameter. If your "schema" parameter can be used in that way, then you could detect your schema context within your methods and reconnect to the other schema before issuing the query.
    public class UserRepository : GenericRepository<...>
    {
      private string _Schema;
      public UserRepository(string schema) : base(schema)
      {
        _Schema = schema;
      }
      public List<User> GetUsersByLocation(string schema, int locationId)
      {
        if (schema != _Schema)
        {
          return (new UserRepository(schema)).GetUsersByLocation(schema, locationid);
        }
        // query the database ...
      }
    }
A more comprehensive solution would involve a redesigned repository to reduce the number of instantiations for the UserRepository class.
