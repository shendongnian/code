    class User
    {
      private IAuthenticator authenticator;
      public string Name { get; set; }
      public Guid Id { get; set; }
      public User(string name, Guid id, IAuthenticator authenticator)
      {
        Name = name;
        Id = id;
        this.authenticator = authenticator;
      }
      public Rights Authenticate()
      {
        return authenticator.Authenticate(Name, Id);
      }
    }
