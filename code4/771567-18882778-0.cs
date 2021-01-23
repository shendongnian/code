    public interface IFakeDbConnectionFactory
    {
        string Name { get; set; }
    }
    public class FakeDbConnectionFactory : IFakeDbConnectionFactory
    {
        public string Name { get; set; }
    }
    public class UsersControlSettingsRepository {
        public IFakeDbConnectionFactory Conn { get; set; }        
    }
    public class AppHost : AppHostHttpListenerBase
    {
        public AppHost() : base("Test App", typeof (AppHost).Assembly) {}
        public override void Configure(Container container)
        {
            var conn = new FakeDbConnectionFactory { Name = "TestDB1"};
            container.Register<IFakeDbConnectionFactory>(c => conn);
            container.Register(c => new UsersControlSettingsRepository {
                Conn = c.TryResolve<IFakeDbConnectionFactory>()
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppHost();
            app.Init();
            app.Start(@"http://+:8085/");
            var repo = EndpointHost.AppHost.TryResolve<UsersControlSettingsRepository>();
            Console.WriteLine(repo.Conn.Name);
            Console.ReadLine();
        }
    }
