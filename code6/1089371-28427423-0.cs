    public interface IUserContext
    {
        string CurrentUser { get; } 
    }
    public class HttpUserContext : IUserContext
    {
        public string CurrentUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
    public class ConnectionStringFactory
    {
        private readonly IUserContext userContext;
        private readonly string partialConnectionString;
        public ConnectionStringFactory(
            IUserContext userContext, 
            string partialConnectionString)
        {
            this.userContext = userContext;
            this.partialConnectionString = partialConnectionString;
        }
        public string GetConnectionString()
        {
                var builder = new SqlConnectionStringBuilder(partialConnectionString);
                builder.UserID = this.userContext.CurrentUser;
                return builder.ConnectionString;
        }
    }
    //register like this
    var connectionStringFactory = new ConnectionStringFactory(
             new HttpUserContext(), 
             "yourconnectionString");
    container.RegisterSingle(connectionStringFactory);
    container.RegisterPerWebRequest<YourDbContext>(() =>
    {
        var connectionFactory = container.GetInstance<ConnectionStringFactory>();
        var entityConnectionString = connectionFactory.GetConnectionString;
        return new YourDbContext(entityConnectionString);
    });
