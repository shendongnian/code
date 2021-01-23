    public class EMDataContext : ObjectContext
    {
          // parameterless ctor, since you're using new() in UnitOfWork<TContext>
          public EMDataContext() : base(???)
          {
          }
          public EMDataContext(string connectionString) : base(connectionString)
          {
          }
    }
