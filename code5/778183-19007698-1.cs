    public class UserRoleService
    {
       pulbic UserRoleService(ModelFactory<UserRole> factory){}
    }
    public class ModelFactory<T>
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }
    }
