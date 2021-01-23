    public class ProjectContextFactory : IProjectContextFactory
    {
      private ProjectContext _currentContext = null;
      private string _currentConnectionString = null;
      private const string ConnectionKey = "ProjectConnection";
      public ProjectContext GetContext()
      {
        // Seriously, don't forget the locking, etc. in here
        // to make this thread-safe! I'm omitting it for simplicity.
        var cs = ConfigurationManager.ConnectionStrings[ConnectionKey].ConnectionString;
        if(this._currentConnectionString != cs)
        {
          this._currentConnectionString = cs;
          var builder = new SqlConnectionStringBuilder(cs);
          builder.InitialCatalog = _Database;
          this._currentContext = new ProjectContext(builder.ToString());
        }
        return this._currentContext;
      }
    }
