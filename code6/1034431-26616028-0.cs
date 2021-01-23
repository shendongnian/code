    public IEnumerable<User> GetAll(System.Linq.Expressions.Expression<Func<UserDTO, bool>> query)
    {
      var prefix = query.Compile();
      query = c => prefix(c) && c.Organisation == organisationID;
    }
    
