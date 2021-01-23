    using LightInject;
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.Register<IUserRepository, UserRepositorySql>("Sql");
            container.Register<IUserRepository, UserRepositoryDefault>("Default");
            container.Register<string, IUserModule>(
                (factory, serviceName) => new UserModule(factory.GetInstance<IUserRepository>(serviceName)));
            var userModuleWithSqlRepository = container.GetInstance<string, IUserModule>("Sql");
            var userModuleWithDefaultRepository = container.GetInstance<string, IUserModule>("Default");
        }
    }
    public interface IUserModule { }
    public class UserModule : IUserModule
    {
        public UserModule(IUserRepository repository)
        {
        }
    }
    public interface IUserRepository { }
    public class UserRepositorySql : IUserRepository { }
    
    public class UserRepositoryDefault : IUserRepository { }
